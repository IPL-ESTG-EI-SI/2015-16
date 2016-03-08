using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Worksheet1_Extra1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bufferSize = 20480;
            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;
            // The file is included in the solution and set to copy to the build folder
            // To check that the file was copied properly right-click on the project and 
            // choose Open in File Explorer, then navigate to bin/Debug
            String originalPath = "security.jpg";
            String destinationPath = "bak_security.jpg";

            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }
            FileStream originalStream = new FileStream(originalPath, FileMode.Open);
            FileStream destinationStream = new FileStream(destinationPath, FileMode.Create);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)originalStream.Length;
            progressBar1.Step = bufferSize;


            while ((bytesRead = originalStream.Read(buffer, 0, bufferSize)) > 0)
            {
                destinationStream.Write(buffer, 0, bytesRead);
                progressBar1.PerformStep();
            }

            originalStream.Close();
            destinationStream.Close();
        }
    }
}
