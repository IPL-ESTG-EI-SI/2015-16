using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1
{
    public partial class Form1 : Form
    {
        private enum ALGORITHMS { AES, TRIPLEDES,DES,RC2,RIJNDAEL};

        SymmetricAlgorithm algorithm;
        byte[] encryptedData;

        public Form1()
        {
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(ALGORITHMS)))
            {
                cbAlgorithm.Items.Add(item);
            }
            cbAlgorithm.SelectedIndex = 0;
            tbPlainText.Text = "EI SI 2015/16";

        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            switch ((ALGORITHMS)cbAlgorithm.SelectedItem)
            {
                case ALGORITHMS.AES: algorithm = new AesCryptoServiceProvider(); break;
                case ALGORITHMS.TRIPLEDES: algorithm = new TripleDESCryptoServiceProvider(); break;
                case ALGORITHMS.DES: algorithm = new DESCryptoServiceProvider(); break;
                case ALGORITHMS.RC2: algorithm = new RC2CryptoServiceProvider(); break;
                case ALGORITHMS.RIJNDAEL: algorithm = new RijndaelManaged(); break;
            }

            byte[] encodedPlainText = Encoding.UTF8.GetBytes(tbPlainText.Text);
            String encryptedEncodedText = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(encodedPlainText, 0, encodedPlainText.Length);
                }
                encryptedData = memoryStream.ToArray();
            }
            encryptedEncodedText =Convert.ToBase64String(encryptedData);
            tbEncrypted.Text = encryptedEncodedText;
            tbDecrypted.Text = "";

        }

        private void btnDecryptTextBox_Click(object sender, EventArgs e)
        {
            byte[] encodedTextBoxText = Convert.FromBase64String(tbEncrypted.Text);
            byte[] decryptedBytes = new byte[encodedTextBoxText.Length];
            try
            {
                using (MemoryStream memoryStream = new MemoryStream(encodedTextBoxText))
                {
                    using(CryptoStream cryptoStream = new CryptoStream(memoryStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                            cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    }
                }
            }
            catch (CryptographicException)
            {
                MessageBox.Show("The algorithm failed do decrypt the data because the UTF8 encoding messed up the structure", "Cryptographical Exception");

            }
            String decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            tbDecrypted.Text = decryptedText;

        }

        private void btnDecryptData_Click(object sender, EventArgs e)
        {
            byte[] decryptedBytes = new byte[encryptedData.Length];

            using (MemoryStream memoryStream = new MemoryStream(encryptedData))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                }
            }
            String decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            tbDecrypted.Text = decryptedText;
        }

        private void btnEncryptSW_Click(object sender, EventArgs e)
        {
            String encryptedEncodedText = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(cryptoStream))
                    {
                        writer.Write(tbPlainText.Text);
                    }
                }
                encryptedData = memoryStream.ToArray();
            }
            encryptedEncodedText = Convert.ToBase64String(encryptedData);
            tbEncrypted.Text = encryptedEncodedText;
            tbDecrypted.Text = "";
        }

        private void btnDecryptSW_Click(object sender, EventArgs e)
        {
            byte[] decryptedBytes = new byte[encryptedData.Length];

            using (MemoryStream memoryStream = new MemoryStream(encryptedData))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using(StreamReader reader = new StreamReader(cryptoStream))
                    {
                        tbDecrypted.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] decryptedBytes = new byte[encryptedData.Length];
            byte[] encryptedFromTextBox = Convert.FromBase64String(tbEncrypted.Text);

            using (MemoryStream memoryStream = new MemoryStream(encryptedFromTextBox))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cryptoStream))
                    {
                        tbDecrypted.Text = reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
 