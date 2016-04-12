namespace Exercise2._1
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
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btbSignHash = new System.Windows.Forms.Button();
            this.btnSignData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHashBytes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBitsHas = new System.Windows.Forms.Label();
            this.lblBitsSignature = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDigitakSignature = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original Message to be Signed";
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(13, 30);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(479, 20);
            this.tbMessage.TabIndex = 1;
            this.tbMessage.Text = "EI SI 2015/16";
            // 
            // btbSignHash
            // 
            this.btbSignHash.Location = new System.Drawing.Point(13, 68);
            this.btbSignHash.Name = "btbSignHash";
            this.btbSignHash.Size = new System.Drawing.Size(174, 23);
            this.btbSignHash.TabIndex = 2;
            this.btbSignHash.Text = "Sign Hash";
            this.btbSignHash.UseVisualStyleBackColor = true;
            this.btbSignHash.Click += new System.EventHandler(this.btbSignHash_Click);
            // 
            // btnSignData
            // 
            this.btnSignData.Location = new System.Drawing.Point(325, 67);
            this.btnSignData.Name = "btnSignData";
            this.btnSignData.Size = new System.Drawing.Size(167, 23);
            this.btnSignData.TabIndex = 3;
            this.btnSignData.Text = "Sign Data";
            this.btnSignData.UseVisualStyleBackColor = true;
            this.btnSignData.Click += new System.EventHandler(this.btnSignData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hash Bytes of the Original Message (Message Digest) [HEX]";
            // 
            // tbHashBytes
            // 
            this.tbHashBytes.Enabled = false;
            this.tbHashBytes.Location = new System.Drawing.Point(13, 144);
            this.tbHashBytes.Multiline = true;
            this.tbHashBytes.Name = "tbHashBytes";
            this.tbHashBytes.Size = new System.Drawing.Size(446, 47);
            this.tbHashBytes.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "bits";
            // 
            // lblBitsHas
            // 
            this.lblBitsHas.AutoSize = true;
            this.lblBitsHas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBitsHas.Location = new System.Drawing.Point(465, 168);
            this.lblBitsHas.MinimumSize = new System.Drawing.Size(20, 2);
            this.lblBitsHas.Name = "lblBitsHas";
            this.lblBitsHas.Size = new System.Drawing.Size(20, 15);
            this.lblBitsHas.TabIndex = 7;
            // 
            // lblBitsSignature
            // 
            this.lblBitsSignature.AutoSize = true;
            this.lblBitsSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBitsSignature.Location = new System.Drawing.Point(464, 262);
            this.lblBitsSignature.MinimumSize = new System.Drawing.Size(20, 2);
            this.lblBitsSignature.Name = "lblBitsSignature";
            this.lblBitsSignature.Size = new System.Drawing.Size(20, 15);
            this.lblBitsSignature.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "bits";
            // 
            // tbDigitakSignature
            // 
            this.tbDigitakSignature.Enabled = false;
            this.tbDigitakSignature.Location = new System.Drawing.Point(12, 238);
            this.tbDigitakSignature.Multiline = true;
            this.tbDigitakSignature.Name = "tbDigitakSignature";
            this.tbDigitakSignature.Size = new System.Drawing.Size(446, 47);
            this.tbDigitakSignature.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(251, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Digital Signature (Encrypted Message Digest) [HEX]";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Verify Hash";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(325, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Verify Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 337);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblBitsSignature);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbDigitakSignature);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblBitsHas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHashBytes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSignData);
            this.Controls.Add(this.btbSignHash);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btbSignHash;
        private System.Windows.Forms.Button btnSignData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbHashBytes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBitsHas;
        private System.Windows.Forms.Label lblBitsSignature;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDigitakSignature;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

