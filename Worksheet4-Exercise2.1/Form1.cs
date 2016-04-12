using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise2._1
{
    public partial class Form1 : Form
    {
        private RSACryptoServiceProvider algorithm;
        private SHA1 sha1;
        private byte[] signature;
       

        public Form1()
        {
            InitializeComponent();
            algorithm = new RSACryptoServiceProvider();
            sha1 = SHA1.Create();
        }

        private void btbSignHash_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.UTF8.GetBytes(tbMessage.Text);
            byte[] hash = sha1.ComputeHash(data);

            tbHashBytes.Text = BitConverter.ToString(hash);
            lblBitsHas.Text = (hash.Length * 8).ToString();

            signature = algorithm.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
            string hexString = BitConverter.ToString(signature);
            tbDigitakSignature.Text = hexString;
            lblBitsSignature.Text = (signature.Length * 8).ToString();

        }

        private void btnSignData_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.UTF8.GetBytes(tbMessage.Text);
            byte[] hash = sha1.ComputeHash(data);

            signature = algorithm.SignData(data,sha1);

            
            string hexString = BitConverter.ToString(signature);
            tbDigitakSignature.Text = hexString;
            lblBitsSignature.Text = (signature.Length * 8).ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.UTF8.GetBytes(tbMessage.Text);
            byte[] hash = sha1.ComputeHash(data);
            if(algorithm.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature))
            {
                MessageBox.Show("Signature Verified");
            }else
            {
                MessageBox.Show("Signature NOT VALID");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.UTF8.GetBytes(tbMessage.Text);
            byte[] hash = sha1.ComputeHash(data);
            if (algorithm.VerifyData(data,sha1,signature))
            {
                MessageBox.Show("Signature Verified");
            }
            else
            {
                MessageBox.Show("Signature NOT VALID");
            }
        }
    }
}
