using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs; // precisa de se adicionar a assembly: System.Security (neste projecto já está adicionada)
using System.Security.Cryptography.X509Certificates;

namespace ManipulacaoCertificados
{
    public partial class Form1 : Form
    {
        // os respectivos certificados deverão ser colocados directoria: /bin/debug
        const string filePFXCert = @"estg.dei.si.a.pfx";
        const string fileCERCert = @"estg.dei.si.a.cer";
        static readonly string pwdfilePFXCert = Properties.Settings.Default.PwdPFX;

        private byte[] tempRawCert = null;
        private byte[] tempData = null;
        private byte[] tempSignature = null;
        private byte[] tempEnvelope = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }







        // Mostrar informação de um certificado
        private void ShowCertificate(X509Certificate2 cert)
        {
            txtInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            txtInfo.Text += "Subject: " + cert.Subject + Environment.NewLine;
            txtInfo.Text += "FriendlyName: " + cert.FriendlyName + Environment.NewLine;
            txtInfo.Text += "Thumbprint: " + cert.Thumbprint + Environment.NewLine;
            txtInfo.Text += "SerialNumber: " + cert.SerialNumber + Environment.NewLine;
            txtInfo.Text += "HasPrivateKey: " + cert.HasPrivateKey + Environment.NewLine;
            txtInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            txtInfo.Text += Environment.NewLine;
        }



        private void btnOpenPFX_Click(object sender, EventArgs e)
        {
            X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);
            ShowCertificate(cert);
        }

        private void btnOpenCER_Click(object sender, EventArgs e)
        {
            X509Certificate2 cert = new X509Certificate2(fileCERCert);
            X509Certificate2UI.DisplayCertificate(cert);
        }

        private void btnOpenFromStore_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            //store.Cer
            X509Certificate2Collection certs =
                    X509Certificate2UI.SelectFromCollection(store.Certificates, "Escolha:", "Escolha um certificado", X509SelectionFlag.SingleSelection);
            if (certs.Count == 1)
            {
                ShowCertificate(certs[0]);
            }
            store.Close();
        }


        private void btnVerifyCert_Click(object sender, EventArgs e)
        {
            X509Certificate2 cert = new X509Certificate2(fileCERCert);
            ShowCertificate(cert);
            MessageBox.Show(cert.Verify().ToString());
        }

        private void btnVerifyCertChain_Click(object sender, EventArgs e)
        {

        }

        private void btnExportPublicCert_Click(object sender, EventArgs e)
        {
            X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);
            ShowCertificate(cert);
            //this.tempRawCert = cert.GetRawCertData();
            this.tempRawCert = cert.Export(X509ContentType.Cert);
        }

        private void btnExportPrivateCert_Click(object sender, EventArgs e)
        {
            X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert, X509KeyStorageFlags.Exportable);
            ShowCertificate(cert);

            this.tempRawCert = cert.Export(X509ContentType.Pfx, pwdfilePFXCert);
        }

        private void btnImportPublicCert_Click(object sender, EventArgs e)
        {
            X509Certificate2 cert = new X509Certificate2(this.tempRawCert);
            ShowCertificate(cert);
        }

        private void btnImportPrivateCert_Click(object sender, EventArgs e)
        {
            X509Certificate2 cert = new X509Certificate2(this.tempRawCert, pwdfilePFXCert);
            ShowCertificate(cert);
        }

        private void btnAddToStoreCER_Click(object sender, EventArgs e)
        {
            X509Certificate2 cert = new X509Certificate2(fileCERCert);
            ShowCertificate(cert);

            // add to store
            X509Store store = new X509Store(StoreName.AddressBook, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            store.Add(cert);
            store.Close();
        }













        private void btnSignatureWithData_Click(object sender, EventArgs e)
        {
            // dados a assinar
            byte[] data = Encoding.UTF8.GetBytes(txtInfo.Text);
            ContentInfo cinfo = new ContentInfo(data);

            // certificado
            X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);
            txtInfo.Text += cert.Verify() + " ";
            CmsSigner signer = new CmsSigner(cert);


            // assinar...
            SignedCms signedCms = new SignedCms(cinfo, false);  // false = not detached
            signedCms.ComputeSignature(signer, false);

            this.tempSignature = signedCms.Encode();

            txtInfo.Text += this.tempSignature.Length.ToString() + " ";
        }

        private void btnVerifySignWithData_Click(object sender, EventArgs e)
        {
            // OBTER MENSAGEM
            SignedCms signedCms = new SignedCms();

            // verificar assinatura
            try
            {
                signedCms.Decode(this.tempSignature);
                signedCms.CheckSignature(false);  // false = integridade + autenticação
                //signedCms.CheckSignature(true);  // true = só integridade 
                MessageBox.Show("OK");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao validar assinatura digital!");
            }
        }

        private void btnSignature_Click(object sender, EventArgs e)
        {
            // dados a assinar
            byte[] data = Encoding.UTF8.GetBytes(txtInfo.Text);
            ContentInfo cinfo = new ContentInfo(data);

            // certificado
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(store.Certificates, "Escolha o certificado:", "Certificados Pessoais", X509SelectionFlag.SingleSelection);
            store.Close();

            if (certs.Count == 0)
                return;

            txtInfo.Text += " " + certs[0].Verify() + " ";
            CmsSigner signer = new CmsSigner(certs[0]);

            txtInfo.Focus();
            // assinar...
            SignedCms signedCms = new SignedCms(cinfo, true);  // true = detached
            signedCms.ComputeSignature(signer, false);

            // exportar mensagem (sem dados) + dados
            this.tempSignature = signedCms.Encode();
            this.tempData = data;

            txtInfo.Text += this.tempSignature.Length.ToString() + " ";
        }

        private void btnVerifySign_Click(object sender, EventArgs e)
        {
            // OBTER MENSAGEM
            byte[] data = Encoding.UTF8.GetBytes(txtInfo.Text);
            SignedCms signedCms = new SignedCms(new ContentInfo(data), true);
            //SignedCms signedCms = new SignedCms(new ContentInfo(this.tempData), true);

            // verificar assinatura
            try
            {
                signedCms.Decode(this.tempSignature);
                signedCms.CheckSignature(false);  // false = integridade + autenticação
                //signedCms.CheckSignature(true);  // true = só integridade 
                MessageBox.Show("OK");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao validar assinatura digital!");
            }
        }






        private void btnEncryptCER_Click(object sender, EventArgs e)
        {
            // dados a cifrar
            byte[] data = Encoding.UTF8.GetBytes(txtInfo.Text);
            ContentInfo cinfo = new ContentInfo(data);

            // certificado
            X509Certificate2 cert = new X509Certificate2(fileCERCert);
            txtInfo.Text += cert.Verify() + " ";
            CmsRecipient recipient = new CmsRecipient(cert);

            // cifrar
            EnvelopedCms envelope = new EnvelopedCms(cinfo);
            envelope.Encrypt(recipient);

            this.tempEnvelope = envelope.Encode();

            txtInfo.Text += this.tempEnvelope.Length.ToString() + " ";
        }


        private void btnDecryptFromPFX_Click(object sender, EventArgs e)
        {
            EnvelopedCms envelope = new EnvelopedCms();
            envelope.Decode(this.tempEnvelope);

            X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);
            envelope.Decrypt(new X509Certificate2Collection(cert));

            txtInfo.Text += Environment.NewLine + Encoding.UTF8.GetString(envelope.ContentInfo.Content) + " ";
        }

        private void btnEncryptStore_Click(object sender, EventArgs e)
        {

        }

        private void btnDecryptFromStore_Click(object sender, EventArgs e)
        {

        }




        private void btnEncryptAndSign_Click(object sender, EventArgs e)
        {
            #region Cifrar
            
            // dados a cifrar
            byte[] data = Encoding.UTF8.GetBytes(txtInfo.Text);
            ContentInfo cinfo = new ContentInfo(data);

            // certificado
            X509Certificate2 cert = new X509Certificate2(fileCERCert);
            txtInfo.Text += cert.Verify() + " ";
            CmsRecipient recipient = new CmsRecipient(cert);

            // cifrar
            EnvelopedCms envelope = new EnvelopedCms(cinfo);
            envelope.Encrypt(recipient);

            #endregion


            #region Assinar 

            // dados a assinar
            data = envelope.Encode();
            cinfo = new ContentInfo(data);

            // certificado
            cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);
            txtInfo.Text += cert.Verify() + " ";
            CmsSigner signer = new CmsSigner(cert);


            // assinar...
            SignedCms signedCms = new SignedCms(cinfo, false);  // false = not detached
            signedCms.ComputeSignature(signer, false);

            this.tempSignature = signedCms.Encode();

            #endregion

            txtInfo.Text += this.tempSignature.Length.ToString() + " ";
        }


        private void btnVerifyAndDecrypt_Click(object sender, EventArgs e)
        {
            // OBTER MENSAGEM
            SignedCms signedCms = new SignedCms();

            // verificar assinatura
            try
            {
                signedCms.Decode(this.tempSignature);
                signedCms.CheckSignature(false);  // false = integridade + autenticação
                //signedCms.CheckSignature(true);  // true = só integridade 
                txtInfo.Text += Environment.NewLine + "Assinatura OK ";

                // decifrar
                EnvelopedCms envelope = new EnvelopedCms();
                envelope.Decode(signedCms.ContentInfo.Content);

                X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);
                envelope.Decrypt(new X509Certificate2Collection(cert));

                txtInfo.Text += Environment.NewLine + Encoding.UTF8.GetString(envelope.ContentInfo.Content) + " ";

            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao validar assinatura digital!");
            }
        }

    }
}