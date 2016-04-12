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

namespace Exercise1._2
{
    public partial class Form1 : Form
    {
        private SHA1 hashAlgorithm;

        public Form1()
        {
            InitializeComponent();
            this.hashAlgorithm = SHA1.Create();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            byte[] data = Encoding.UTF8.GetBytes(tbInput1.Text);
            this.hashAlgorithm.TransformBlock(data, 0, data.Length, data, 0);
            
        }

        private void btnInput2_Click(object sender, EventArgs e)
        {
           
            byte[] data = Encoding.UTF8.GetBytes(tbInput2.Text);
            this.hashAlgorithm.TransformBlock(data, 0, data.Length, data, 0);
            
        }

        private void btnFinal_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.UTF8.GetBytes(tbInputFinal.Text);
            this.hashAlgorithm.TransformFinalBlock(data, 0, data.Length);

            byte[] hash = this.hashAlgorithm.Hash;
            string hexString = BitConverter.ToString(hash);
            tbHash.Text = hexString;
        }
    }
}
