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
        SymmetricAlgorithm algorithm;
        byte[] encryptedData;

        public Form1()
        {
            InitializeComponent();
            algorithm = new AesCryptoServiceProvider();
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
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
 