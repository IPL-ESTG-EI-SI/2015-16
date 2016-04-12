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

namespace Exercise1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMD5_Click(object sender, EventArgs e)
        {
            using (MD5 hashAlgorithm = MD5.Create())
            {
                byte[] hash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(tbData.Text));
                string hexString = BitConverter.ToString(hash);
                tbHash.Text = hexString;
                lblBits.Text = (hash.Length * 8).ToString();

            }
        }

        private void btnSHA1_Click(object sender, EventArgs e)
        {
            using (SHA1 hashAlgorithm = SHA1.Create())
            {
                byte[] hash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(tbData.Text));
                string hexString = BitConverter.ToString(hash);
                tbHash.Text = hexString;
                lblBits.Text = (hash.Length * 8).ToString();

            }
        }

        private void btnSHA512_Click(object sender, EventArgs e)
        {
            using (SHA512 hashAlgorithm = SHA512.Create())
            {
                byte[] hash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(tbData.Text));
                string hexString = BitConverter.ToString(hash);
                tbHash.Text = hexString;
                lblBits.Text = (hash.Length * 8).ToString();

            }
        }
    }
}
