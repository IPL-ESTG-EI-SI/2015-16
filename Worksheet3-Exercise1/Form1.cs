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
        string publicKeyPath = "public.txt";
        string bothKeyPath = "private-public.txt";
        string publicKey;
        string bothKeys;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                publicKey = algorithm.ToXmlString(false);
                tbPrivateKey.Text = publicKey;
                bothKeys = algorithm.ToXmlString(true);
                tbBothKeys.Text = bothKeys;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(publicKeyPath, publicKey);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText(bothKeyPath, bothKeys);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using(RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                algorithm.FromXmlString(publicKey);
                byte[] clearKey = Encoding.UTF8.GetBytes(tbSymmentricKey.Text);
                byte[] encryptedKey = algorithm.Encrypt(clearKey, true);
                tbSymmetricKeyEncrtypted.Text = Convert.ToBase64String(encryptedKey);
                tbBitSize.Text = (encryptedKey.Length * 8).ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(bothKeys);
                byte[] decryptedKey = provider.Decrypt(Convert.FromBase64String(tbSymmetricKeyEncrtypted.Text), true);
                tbSymmetricKeyDecrypted.Text = Encoding.UTF8.GetString(decryptedKey);
            }
        }
    }
}
