namespace Exercise1._1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbData = new System.Windows.Forms.TextBox();
            this.btnMD5 = new System.Windows.Forms.Button();
            this.btnSHA1 = new System.Windows.Forms.Button();
            this.btnSHA512 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHash = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBits = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data to Compute";
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(13, 30);
            this.tbData.Multiline = true;
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(395, 47);
            this.tbData.TabIndex = 1;
            this.tbData.Text = "Data.to.Compute.Hash";
            // 
            // btnMD5
            // 
            this.btnMD5.Location = new System.Drawing.Point(13, 84);
            this.btnMD5.Name = "btnMD5";
            this.btnMD5.Size = new System.Drawing.Size(118, 23);
            this.btnMD5.TabIndex = 2;
            this.btnMD5.Text = "MD5-ComputeHash";
            this.btnMD5.UseVisualStyleBackColor = true;
            this.btnMD5.Click += new System.EventHandler(this.btnMD5_Click);
            // 
            // btnSHA1
            // 
            this.btnSHA1.Location = new System.Drawing.Point(138, 84);
            this.btnSHA1.Name = "btnSHA1";
            this.btnSHA1.Size = new System.Drawing.Size(130, 23);
            this.btnSHA1.TabIndex = 3;
            this.btnSHA1.Text = "SHA1-ComputeHash";
            this.btnSHA1.UseVisualStyleBackColor = true;
            this.btnSHA1.Click += new System.EventHandler(this.btnSHA1_Click);
            // 
            // btnSHA512
            // 
            this.btnSHA512.Location = new System.Drawing.Point(275, 84);
            this.btnSHA512.Name = "btnSHA512";
            this.btnSHA512.Size = new System.Drawing.Size(133, 23);
            this.btnSHA512.TabIndex = 4;
            this.btnSHA512.Text = "SHA512-ComputeHash";
            this.btnSHA512.UseVisualStyleBackColor = true;
            this.btnSHA512.Click += new System.EventHandler(this.btnSHA512_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hash In HEX";
            // 
            // tbHash
            // 
            this.tbHash.Location = new System.Drawing.Point(13, 155);
            this.tbHash.Multiline = true;
            this.tbHash.Name = "tbHash";
            this.tbHash.Size = new System.Drawing.Size(395, 62);
            this.tbHash.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "bits";
            // 
            // lblBits
            // 
            this.lblBits.AutoSize = true;
            this.lblBits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBits.Location = new System.Drawing.Point(375, 128);
            this.lblBits.MinimumSize = new System.Drawing.Size(30, 0);
            this.lblBits.Name = "lblBits";
            this.lblBits.Size = new System.Drawing.Size(30, 15);
            this.lblBits.TabIndex = 8;
            this.lblBits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 229);
            this.Controls.Add(this.lblBits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSHA512);
            this.Controls.Add(this.btnSHA1);
            this.Controls.Add(this.btnMD5);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Worksheet 4 - Hash Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.Button btnMD5;
        private System.Windows.Forms.Button btnSHA1;
        private System.Windows.Forms.Button btnSHA512;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbHash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBits;
    }
}

