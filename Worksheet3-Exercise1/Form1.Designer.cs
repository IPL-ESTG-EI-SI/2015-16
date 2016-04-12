namespace Exercise1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrivateKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBothKeys = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSymmentricKey = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSymmetricKeyEncrtypted = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBitSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSymmetricKeyDecrypted = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate Keys (Private / Public)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Public Key";
            // 
            // tbPrivateKey
            // 
            this.tbPrivateKey.Location = new System.Drawing.Point(13, 60);
            this.tbPrivateKey.Multiline = true;
            this.tbPrivateKey.Name = "tbPrivateKey";
            this.tbPrivateKey.Size = new System.Drawing.Size(492, 53);
            this.tbPrivateKey.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Private / Public Key";
            // 
            // tbBothKeys
            // 
            this.tbBothKeys.Location = new System.Drawing.Point(13, 146);
            this.tbBothKeys.Multiline = true;
            this.tbBothKeys.Name = "tbBothKeys";
            this.tbBothKeys.Size = new System.Drawing.Size(492, 119);
            this.tbBothKeys.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(365, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save PublicKey.txt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(365, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Save PrivatePublicKey.txt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.tbSymmetricKeyDecrypted);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbBitSize);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbSymmetricKeyEncrtypted);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.tbSymmentricKey);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 169);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Symmetric Key to Encrypt";
            // 
            // tbSymmentricKey
            // 
            this.tbSymmentricKey.Location = new System.Drawing.Point(138, 9);
            this.tbSymmentricKey.Name = "tbSymmentricKey";
            this.tbSymmentricKey.Size = new System.Drawing.Size(225, 20);
            this.tbSymmentricKey.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(369, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Encrypt";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Encrypted Symmetric Key";
            // 
            // tbSymmetricKeyEncrtypted
            // 
            this.tbSymmetricKeyEncrtypted.Location = new System.Drawing.Point(138, 39);
            this.tbSymmetricKeyEncrtypted.Multiline = true;
            this.tbSymmetricKeyEncrtypted.Name = "tbSymmetricKeyEncrtypted";
            this.tbSymmetricKeyEncrtypted.Size = new System.Drawing.Size(348, 74);
            this.tbSymmetricKeyEncrtypted.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Number of Bits";
            // 
            // tbBitSize
            // 
            this.tbBitSize.Location = new System.Drawing.Point(12, 92);
            this.tbBitSize.Name = "tbBitSize";
            this.tbBitSize.Size = new System.Drawing.Size(100, 20);
            this.tbBitSize.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Decrypted Symmetric Key";
            // 
            // tbSymmetricKeyDecrypted
            // 
            this.tbSymmetricKeyDecrypted.Location = new System.Drawing.Point(138, 133);
            this.tbSymmetricKeyDecrypted.Name = "tbSymmetricKeyDecrypted";
            this.tbSymmetricKeyDecrypted.Size = new System.Drawing.Size(225, 20);
            this.tbSymmetricKeyDecrypted.TabIndex = 8;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(369, 129);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Decrypt";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 452);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbBothKeys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPrivateKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPrivateKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBothKeys;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tbSymmetricKeyDecrypted;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbBitSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSymmetricKeyEncrtypted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbSymmentricKey;
        private System.Windows.Forms.Label label3;
    }
}

