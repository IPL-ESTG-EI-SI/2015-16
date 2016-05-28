using DevScope.CartaoDeCidadao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using WindowsClient.AuthService;
using WindowsClient.TSAService;

namespace WindowsClient
{
    public partial class FormMain : Form
    {
        private const string DATA_FILE = "DataFile.txt";
        private const int TIMESTAMP_SIZE = 18;
        private const string filePFXCert = @"estg.dei.si.a.pfx";
        private const string fileCERCert = @"estg.dei.si.a.cer";
        private const string fileSignature = @"signature.dat";
        private const string fileTimestamp = @"timestamp.dat";
        static readonly string pwdfilePFXCert = Properties.Settings.Default.PwdPFX;

        private byte[] DataForReplayAttack { get; set; }

        private SCWatcher _scWatcher = null;
        private X509Certificate2 certificate;

        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Obter a lista de utilizadores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUsers_Click(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();
            string login = txtLogin.Text;
            string pass = txtPassword.Text;
            User[] users = client.GetUsers(login, pass);
            if(users == null)
            {
                MessageBox.Show("Not Authenticated / Authorized");
            } else
            {
                lboxUsers.Items.AddRange(users.Select(u => new ExtendedUser(u)).ToArray());
            }

            
        }


        /// <summary>
        /// Obter a descrição de um utilizador 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetDescription_Click(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();
            if(lboxUsers.SelectedItem != null)
            {
                txtDescription.Text = client.GetUserDescription(((ExtendedUser)lboxUsers.SelectedItem).Login);
            }else
            {
                MessageBox.Show("You need to select a user first!");
            }
            
        }

        /// <summary>
        /// Atualizar a descrição de um utilizador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetDescription_Click(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();
            string login = txtLogin.Text;
            string pass = txtPassword.Text;
            MessageBox.Show(client.SetUserDescription(login, pass, txtMyDescription.Text));
        }

        private void btnSignFileTimestamp_Click(object sender, EventArgs e)
        {
            byte[] data = File.ReadAllBytes(DATA_FILE);

            X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);

            CmsSigner signer = new CmsSigner(cert);

            ContentInfo cinfo = new ContentInfo(data);

            SignedCms signedCms = new SignedCms(cinfo, false);

            signedCms.ComputeSignature(signer, false);

            byte[] signature = signedCms.Encode();

            SHA1 sha1 = SHA1.Create();

            byte[] signatureHash = sha1.ComputeHash(signature);
            TSAClient client = new TSAClient();
            byte[] tsaTimestamp = Convert.FromBase64String(client.GetTimestamp(Convert.ToBase64String(signatureHash)));

            File.WriteAllBytes(fileSignature, signature);

            File.WriteAllBytes(fileTimestamp, tsaTimestamp);

            MessageBox.Show("Signature and Timestamp Saved");
        }

        private void btnSignVerifyTimestamp_Click(object sender, EventArgs e)
        {
            // OBTER MENSAGEM
            SignedCms signedCms = new SignedCms();

            // verificar assinatura
            try
            {
                byte[] signature = File.ReadAllBytes(fileSignature);
                signedCms.Decode(signature);
                signedCms.CheckSignature(false);

                byte[] tsaTimestamp = File.ReadAllBytes(fileTimestamp);
                byte[] signedTimestamp = new byte[tsaTimestamp.Length- TIMESTAMP_SIZE];
                byte[] timestamp = new byte[TIMESTAMP_SIZE]; 
                Array.Copy(tsaTimestamp, timestamp, TIMESTAMP_SIZE);
                Array.Copy(tsaTimestamp, TIMESTAMP_SIZE, signedTimestamp, 0, signedTimestamp.Length);

                string dateString = Encoding.UTF8.GetString(timestamp);
                DateTime date = DateTime.ParseExact(dateString, "yyyyMMddHHmmssffff",null);

                signedCms.Decode(signedTimestamp);
                signedCms.CheckSignature(false);

                SHA1 sha1 = SHA1.Create();

                byte[] signatureHash = sha1.ComputeHash(signature);

                
                byte[] concatenatedBytes = new byte[signatureHash.Length + timestamp.Length];
                Array.Copy(signatureHash, 0, concatenatedBytes, 0, signatureHash.Length);
                Array.Copy(timestamp, 0, concatenatedBytes, signatureHash.Length, timestamp.Length);

                byte[] tsaHash = sha1.ComputeHash(concatenatedBytes);

                Console.WriteLine(Convert.ToBase64String(tsaHash));
                Console.WriteLine(Convert.ToBase64String(tsaHash));
                Console.WriteLine(Convert.ToBase64String(tsaHash));

                if (signedCms.ContentInfo.Content.SequenceEqual(tsaHash))
                {
                    MessageBox.Show("Signature and Timestamp Validated. File Signed in "+
                                    date.ToString("yyyy-MM-dd")+
                                    Environment.NewLine+" at "+ 
                                    date.ToString("HH:mm:ss"));
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao validar assinatura digital! + timestamp");
            }
        }

        private void btnChooseCert_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection authCerts = store.Certificates.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.KeyAgreement, true);
            X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(authCerts, "Certificados Pessoais", "Escolha o certificado:", X509SelectionFlag.SingleSelection);
            store.Close();
            if (certs.Count == 0)
                return;

            certificate = certs[0];
            lblStatus.Text = "Certificate Defined ";
        }

        private void btnAssocCC_Click(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();

            byte[] data = Encoding.UTF8.GetBytes(certificate.Thumbprint);
            ContentInfo cinfo = new ContentInfo(data);

            
            CmsSigner signer = new CmsSigner(certificate);

            SignedCms signedCms = new SignedCms(cinfo, false);  
            signedCms.ComputeSignature(signer, false);

            byte [] signature = signedCms.Encode();


            string result = client.SetUserCertificate(txtLogin.Text,txtPassword.Text, Convert.ToBase64String(signature));
            MessageBox.Show(result);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            // Init Card Reader
            try
            {
                lblStatus.Text = "initializing the card reader...";
                ScWatcher_Init();

                //this._ccPT = new CitizenCardPT(this._scWatcher);

                lblStatus.Text += " OK.";
            }
            catch
            {
                lblStatus.Text = "Erro ao iniciar o leitor de cartões!";
            }
        }


        #region CartaoDeCidadao Code

        /// <summary>
        /// Read the Citizen ID data and sets the class properties
        /// </summary>
        public void CC_Read_And_Show_Info()
        {
            //Address morada = EIDPT.GetAddress();
            //textBox3.Text = morada.Locality;

            // Public Citizen Identity Data   
            Id citizen = EIDPT.GetID();

            txtIdNumber.Text = citizen.BI;
            //... code
            txtFullName.Text = citizen.FirstName + " " + citizen.Name;
            txtNIF.Text = citizen.NIF;

            pbPhoto.Image = CC_Read_Photo();


        }

        /// <summary>
        /// Only Reads the photo, set's the class properties and returns the photo
        /// </summary>
        /// <returns>Citizen photo</returns>
        public Image CC_Read_Photo()
        {
            MemoryStream ms = null;
            try
            {
                Picture picture = EIDPT.GetPicture();
                ms = new MemoryStream(picture.Bytes, 0, picture.BytesLength, false);
                // JPEG2000 Support provided by CSJ2K (http://csj2k.codeplex.com/)
                Image tempImage = CSJ2K.J2kImage.FromStream(ms);
                return tempImage;
            }
            finally
            {
                ms.Close();
            }
        }
        #endregion

        #region Card Reader Code
        // Manage
        private void ScWatcher_Init()
        {
            this._scWatcher = SCWatcher.GetInstance(); // Daemon starts when instantiated
            this._scWatcher.CardInserted += new SCWatcher.CardInsertedHandler(ScWatcher_CardInserted);
            this._scWatcher.CardRemoved += new SCWatcher.CardRemovedHandler(ScWatcher_CardRemoved);
            this._scWatcher.ReaderInserted += new SCWatcher.ReaderInsertedHandler(ScWatcher_ReaderInserted);
            this._scWatcher.ReaderRemoved += new SCWatcher.ReaderRemovedHandler(ScWatcher_ReaderRemoved);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ScWatcher_Stop()
        {
            if (this._scWatcher != null)
                this._scWatcher.Stop();
        }

        // Events(only for UI update)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerName"></param>
        /// <param name="cardName"></param>
        void ScWatcher_CardInserted(string readerName, string cardName)
        {
            try
            {
                EIDPT.Init(readerName);
                EIDPT.SetSODChecking(false);
            }
            catch
            {
                EIDPT.Exit(ExitMode.LEAVE_CARD);
                return;
            }

            lblStatus.Text = "Card Inserted.";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerName"></param>
        void ScWatcher_CardRemoved(string readerName)
        {
            EIDPT.Exit(ExitMode.LEAVE_CARD);
            lblStatus.Text = "Card Removed.";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerName"></param>
        void ScWatcher_ReaderInserted(string readerName)
        {
            lblStatus.Text = "Card Reader Inserted: " + readerName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerName"></param>
        void ScWatcher_ReaderRemoved(string readerName)
        {
            EIDPT.Exit(ExitMode.LEAVE_CARD);
            lblStatus.Text = "Card Reader Removed:" + readerName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        void ScWatcher_OnError(int errorCode, string errorMessage)
        {
        }
        #endregion

        private void btnReadCC_Click(object sender, EventArgs e)
        {
            CC_Read_And_Show_Info();
        }

        private void btnGetUsersCert_Click(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();
            byte[] data = Encoding.UTF8.GetBytes(certificate.Thumbprint);
            ContentInfo cinfo = new ContentInfo(data);


            CmsSigner signer = new CmsSigner(certificate);

            SignedCms signedCms = new SignedCms(cinfo, false);
            signedCms.ComputeSignature(signer, false);

            byte[] signature = signedCms.Encode();

            this.DataForReplayAttack = signature;

            User[] users = client.GetUsersByCertificate(Convert.ToBase64String(signature));
            if (users == null)
            {
                MessageBox.Show("Not Authenticated / Authorized");
            }
            else
            {
                lboxUsers.Items.AddRange(users.Select(u => new ExtendedUser(u)).ToArray());
            }
        }

        private void btnSQLInjection_Click(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();

            String query = txtSQLInjection.Text;

            String result  = client.GetUserDescription(query);

            MessageBox.Show("User admin's password changed to 456");
            
        }

        private void btnReplayAttack_Click(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();

            User[] users = client.GetUsersByCertificate(Convert.ToBase64String(this.DataForReplayAttack));
            if (users == null)
            {
                MessageBox.Show("Replay Attack Failed");
            }
            else
            {
                MessageBox.Show("Replay Attack Succeded - Got " + users.Length + " Records");
            }
        }
    }
}
