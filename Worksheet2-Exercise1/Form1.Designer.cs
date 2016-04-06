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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPlainText = new System.Windows.Forms.TextBox();
            this.Encrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEncrypted = new System.Windows.Forms.TextBox();
            this.btnDecryptTextBox = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDecrypted = new System.Windows.Forms.TextBox();
            this.btnDecryptSW = new System.Windows.Forms.Button();
            this.btnDecryptData = new System.Windows.Forms.Button();
            this.btnEncryptSW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text to Encrypt";
            // 
            // tbPlainText
            // 
            this.tbPlainText.Location = new System.Drawing.Point(16, 40);
            this.tbPlainText.Name = "tbPlainText";
            this.tbPlainText.Size = new System.Drawing.Size(366, 20);
            this.tbPlainText.TabIndex = 1;
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(16, 66);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(160, 23);
            this.Encrypt.TabIndex = 2;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Encrypted Text (UTF 8)";
            // 
            // tbEncrypted
            // 
            this.tbEncrypted.Location = new System.Drawing.Point(16, 134);
            this.tbEncrypted.Multiline = true;
            this.tbEncrypted.Name = "tbEncrypted";
            this.tbEncrypted.Size = new System.Drawing.Size(366, 68);
            this.tbEncrypted.TabIndex = 4;
            // 
            // btnDecryptTextBox
            // 
            this.btnDecryptTextBox.Location = new System.Drawing.Point(16, 220);
            this.btnDecryptTextBox.Name = "btnDecryptTextBox";
            this.btnDecryptTextBox.Size = new System.Drawing.Size(160, 23);
            this.btnDecryptTextBox.TabIndex = 5;
            this.btnDecryptTextBox.Text = "Decrypt using TextBox data";
            this.btnDecryptTextBox.UseVisualStyleBackColor = true;
            this.btnDecryptTextBox.Click += new System.EventHandler(this.btnDecryptTextBox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Decrypted Text";
            // 
            // tbDecrypted
            // 
            this.tbDecrypted.Location = new System.Drawing.Point(16, 316);
            this.tbDecrypted.Name = "tbDecrypted";
            this.tbDecrypted.Size = new System.Drawing.Size(366, 20);
            this.tbDecrypted.TabIndex = 7;
            // 
            // btnDecryptSW
            // 
            this.btnDecryptSW.Location = new System.Drawing.Point(211, 249);
            this.btnDecryptSW.Name = "btnDecryptSW";
            this.btnDecryptSW.Size = new System.Drawing.Size(171, 38);
            this.btnDecryptSW.TabIndex = 10;
            this.btnDecryptSW.Text = "Decrypt using data and StreamReader";
            this.btnDecryptSW.UseVisualStyleBackColor = true;
            this.btnDecryptSW.Click += new System.EventHandler(this.btnDecryptSW_Click);
            // 
            // btnDecryptData
            // 
            this.btnDecryptData.Location = new System.Drawing.Point(211, 220);
            this.btnDecryptData.Name = "btnDecryptData";
            this.btnDecryptData.Size = new System.Drawing.Size(171, 23);
            this.btnDecryptData.TabIndex = 8;
            this.btnDecryptData.Text = "Decrypt using data";
            this.btnDecryptData.UseVisualStyleBackColor = true;
            this.btnDecryptData.Click += new System.EventHandler(this.btnDecryptData_Click);
            // 
            // btnEncryptSW
            // 
            this.btnEncryptSW.Location = new System.Drawing.Point(211, 65);
            this.btnEncryptSW.Name = "btnEncryptSW";
            this.btnEncryptSW.Size = new System.Drawing.Size(171, 23);
            this.btnEncryptSW.TabIndex = 9;
            this.btnEncryptSW.Text = "Encrypt using StreamWriter";
            this.btnEncryptSW.UseVisualStyleBackColor = true;
            this.btnEncryptSW.Click += new System.EventHandler(this.btnEncryptSW_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 357);
            this.Controls.Add(this.btnDecryptSW);
            this.Controls.Add(this.btnEncryptSW);
            this.Controls.Add(this.btnDecryptData);
            this.Controls.Add(this.tbDecrypted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDecryptTextBox);
            this.Controls.Add(this.tbEncrypted);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.tbPlainText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPlainText;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEncrypted;
        private System.Windows.Forms.Button btnDecryptTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDecrypted;
        private System.Windows.Forms.Button btnDecryptSW;
        private System.Windows.Forms.Button btnDecryptData;
        private System.Windows.Forms.Button btnEncryptSW;
    }
}

