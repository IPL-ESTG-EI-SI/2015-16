namespace ManipulacaoCertificados
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
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnOpenPFX = new System.Windows.Forms.Button();
            this.btnOpenCER = new System.Windows.Forms.Button();
            this.btnOpenFromStore = new System.Windows.Forms.Button();
            this.btnVerifyCert = new System.Windows.Forms.Button();
            this.btnVerifyCertChain = new System.Windows.Forms.Button();
            this.btnExportPublicCert = new System.Windows.Forms.Button();
            this.btnImportPublicCert = new System.Windows.Forms.Button();
            this.btnExportPrivateCert = new System.Windows.Forms.Button();
            this.btnImportPrivateCert = new System.Windows.Forms.Button();
            this.btnAddToStoreCER = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDecryptFromStore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignatureWithData = new System.Windows.Forms.Button();
            this.btnDecryptFromPFX = new System.Windows.Forms.Button();
            this.btnSignature = new System.Windows.Forms.Button();
            this.btnEncryptStore = new System.Windows.Forms.Button();
            this.btnVerifySignWithData = new System.Windows.Forms.Button();
            this.btnEncryptCER = new System.Windows.Forms.Button();
            this.btnVerifySign = new System.Windows.Forms.Button();
            this.btnEncryptAndSign = new System.Windows.Forms.Button();
            this.btnVerifyAndDecrypt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 170);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(637, 253);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Text = "dados";
            // 
            // btnOpenPFX
            // 
            this.btnOpenPFX.Location = new System.Drawing.Point(12, 12);
            this.btnOpenPFX.Name = "btnOpenPFX";
            this.btnOpenPFX.Size = new System.Drawing.Size(134, 27);
            this.btnOpenPFX.TabIndex = 1;
            this.btnOpenPFX.Text = "1) Open File .PFX";
            this.btnOpenPFX.UseVisualStyleBackColor = true;
            this.btnOpenPFX.Click += new System.EventHandler(this.btnOpenPFX_Click);
            // 
            // btnOpenCER
            // 
            this.btnOpenCER.Location = new System.Drawing.Point(12, 41);
            this.btnOpenCER.Name = "btnOpenCER";
            this.btnOpenCER.Size = new System.Drawing.Size(134, 27);
            this.btnOpenCER.TabIndex = 2;
            this.btnOpenCER.Text = "2) Open File .CER";
            this.btnOpenCER.UseVisualStyleBackColor = true;
            this.btnOpenCER.Click += new System.EventHandler(this.btnOpenCER_Click);
            // 
            // btnOpenFromStore
            // 
            this.btnOpenFromStore.Location = new System.Drawing.Point(12, 70);
            this.btnOpenFromStore.Name = "btnOpenFromStore";
            this.btnOpenFromStore.Size = new System.Drawing.Size(134, 27);
            this.btnOpenFromStore.TabIndex = 3;
            this.btnOpenFromStore.Text = "3) Open from Store";
            this.btnOpenFromStore.UseVisualStyleBackColor = true;
            this.btnOpenFromStore.Click += new System.EventHandler(this.btnOpenFromStore_Click);
            // 
            // btnVerifyCert
            // 
            this.btnVerifyCert.Location = new System.Drawing.Point(12, 100);
            this.btnVerifyCert.Name = "btnVerifyCert";
            this.btnVerifyCert.Size = new System.Drawing.Size(134, 27);
            this.btnVerifyCert.TabIndex = 4;
            this.btnVerifyCert.Text = "4) Verify (Normal)";
            this.btnVerifyCert.UseVisualStyleBackColor = true;
            this.btnVerifyCert.Click += new System.EventHandler(this.btnVerifyCert_Click);
            // 
            // btnVerifyCertChain
            // 
            this.btnVerifyCertChain.Location = new System.Drawing.Point(12, 137);
            this.btnVerifyCertChain.Name = "btnVerifyCertChain";
            this.btnVerifyCertChain.Size = new System.Drawing.Size(134, 27);
            this.btnVerifyCertChain.TabIndex = 5;
            this.btnVerifyCertChain.Text = "Extra) Verify (Chain)";
            this.btnVerifyCertChain.UseVisualStyleBackColor = true;
            this.btnVerifyCertChain.Click += new System.EventHandler(this.btnVerifyCertChain_Click);
            // 
            // btnExportPublicCert
            // 
            this.btnExportPublicCert.Location = new System.Drawing.Point(152, 12);
            this.btnExportPublicCert.Name = "btnExportPublicCert";
            this.btnExportPublicCert.Size = new System.Drawing.Size(134, 27);
            this.btnExportPublicCert.TabIndex = 15;
            this.btnExportPublicCert.Text = "5) Export Public (.cer)";
            this.btnExportPublicCert.UseVisualStyleBackColor = true;
            this.btnExportPublicCert.Click += new System.EventHandler(this.btnExportPublicCert_Click);
            // 
            // btnImportPublicCert
            // 
            this.btnImportPublicCert.Location = new System.Drawing.Point(152, 70);
            this.btnImportPublicCert.Name = "btnImportPublicCert";
            this.btnImportPublicCert.Size = new System.Drawing.Size(134, 27);
            this.btnImportPublicCert.TabIndex = 16;
            this.btnImportPublicCert.Text = "7) Import Public (.cer)";
            this.btnImportPublicCert.UseVisualStyleBackColor = true;
            this.btnImportPublicCert.Click += new System.EventHandler(this.btnImportPublicCert_Click);
            // 
            // btnExportPrivateCert
            // 
            this.btnExportPrivateCert.Location = new System.Drawing.Point(152, 41);
            this.btnExportPrivateCert.Name = "btnExportPrivateCert";
            this.btnExportPrivateCert.Size = new System.Drawing.Size(134, 27);
            this.btnExportPrivateCert.TabIndex = 15;
            this.btnExportPrivateCert.Text = "6) Export Private (.pfx)";
            this.btnExportPrivateCert.UseVisualStyleBackColor = true;
            this.btnExportPrivateCert.Click += new System.EventHandler(this.btnExportPrivateCert_Click);
            // 
            // btnImportPrivateCert
            // 
            this.btnImportPrivateCert.Location = new System.Drawing.Point(152, 100);
            this.btnImportPrivateCert.Name = "btnImportPrivateCert";
            this.btnImportPrivateCert.Size = new System.Drawing.Size(134, 27);
            this.btnImportPrivateCert.TabIndex = 16;
            this.btnImportPrivateCert.Text = "8) Import Private (.pfx)";
            this.btnImportPrivateCert.UseVisualStyleBackColor = true;
            this.btnImportPrivateCert.Click += new System.EventHandler(this.btnImportPrivateCert_Click);
            // 
            // btnAddToStoreCER
            // 
            this.btnAddToStoreCER.Location = new System.Drawing.Point(152, 137);
            this.btnAddToStoreCER.Name = "btnAddToStoreCER";
            this.btnAddToStoreCER.Size = new System.Drawing.Size(134, 27);
            this.btnAddToStoreCER.TabIndex = 5;
            this.btnAddToStoreCER.Text = "Extra) Add to Store (.cer)";
            this.btnAddToStoreCER.UseVisualStyleBackColor = true;
            this.btnAddToStoreCER.Click += new System.EventHandler(this.btnAddToStoreCER_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "->";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "->";
            // 
            // btnDecryptFromStore
            // 
            this.btnDecryptFromStore.Location = new System.Drawing.Point(508, 100);
            this.btnDecryptFromStore.Name = "btnDecryptFromStore";
            this.btnDecryptFromStore.Size = new System.Drawing.Size(141, 27);
            this.btnDecryptFromStore.TabIndex = 26;
            this.btnDecryptFromStore.Text = "16) Decrypt (Store)";
            this.btnDecryptFromStore.UseVisualStyleBackColor = true;
            this.btnDecryptFromStore.Click += new System.EventHandler(this.btnDecryptFromStore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "->";
            // 
            // btnSignatureWithData
            // 
            this.btnSignatureWithData.Location = new System.Drawing.Point(327, 12);
            this.btnSignatureWithData.Name = "btnSignatureWithData";
            this.btnSignatureWithData.Size = new System.Drawing.Size(164, 27);
            this.btnSignatureWithData.TabIndex = 19;
            this.btnSignatureWithData.Text = "9) Sign [withData] (.pfx)";
            this.btnSignatureWithData.UseVisualStyleBackColor = true;
            this.btnSignatureWithData.Click += new System.EventHandler(this.btnSignatureWithData_Click);
            // 
            // btnDecryptFromPFX
            // 
            this.btnDecryptFromPFX.Location = new System.Drawing.Point(508, 70);
            this.btnDecryptFromPFX.Name = "btnDecryptFromPFX";
            this.btnDecryptFromPFX.Size = new System.Drawing.Size(141, 27);
            this.btnDecryptFromPFX.TabIndex = 25;
            this.btnDecryptFromPFX.Text = "14) Decrypt (.pfx)";
            this.btnDecryptFromPFX.UseVisualStyleBackColor = true;
            this.btnDecryptFromPFX.Click += new System.EventHandler(this.btnDecryptFromPFX_Click);
            // 
            // btnSignature
            // 
            this.btnSignature.Location = new System.Drawing.Point(327, 41);
            this.btnSignature.Name = "btnSignature";
            this.btnSignature.Size = new System.Drawing.Size(164, 27);
            this.btnSignature.TabIndex = 20;
            this.btnSignature.Text = "11) Sign [withoutData] (Store)";
            this.btnSignature.UseVisualStyleBackColor = true;
            this.btnSignature.Click += new System.EventHandler(this.btnSignature_Click);
            // 
            // btnEncryptStore
            // 
            this.btnEncryptStore.Location = new System.Drawing.Point(327, 100);
            this.btnEncryptStore.Name = "btnEncryptStore";
            this.btnEncryptStore.Size = new System.Drawing.Size(164, 27);
            this.btnEncryptStore.TabIndex = 24;
            this.btnEncryptStore.Text = "15) Encrypt (Store)";
            this.btnEncryptStore.UseVisualStyleBackColor = true;
            this.btnEncryptStore.Click += new System.EventHandler(this.btnEncryptStore_Click);
            // 
            // btnVerifySignWithData
            // 
            this.btnVerifySignWithData.Location = new System.Drawing.Point(508, 12);
            this.btnVerifySignWithData.Name = "btnVerifySignWithData";
            this.btnVerifySignWithData.Size = new System.Drawing.Size(141, 27);
            this.btnVerifySignWithData.TabIndex = 21;
            this.btnVerifySignWithData.Text = "10) Verify Signature";
            this.btnVerifySignWithData.UseVisualStyleBackColor = true;
            this.btnVerifySignWithData.Click += new System.EventHandler(this.btnVerifySignWithData_Click);
            // 
            // btnEncryptCER
            // 
            this.btnEncryptCER.Location = new System.Drawing.Point(327, 70);
            this.btnEncryptCER.Name = "btnEncryptCER";
            this.btnEncryptCER.Size = new System.Drawing.Size(164, 27);
            this.btnEncryptCER.TabIndex = 23;
            this.btnEncryptCER.Text = "13) Encrypt (.cer)";
            this.btnEncryptCER.UseVisualStyleBackColor = true;
            this.btnEncryptCER.Click += new System.EventHandler(this.btnEncryptCER_Click);
            // 
            // btnVerifySign
            // 
            this.btnVerifySign.Location = new System.Drawing.Point(508, 41);
            this.btnVerifySign.Name = "btnVerifySign";
            this.btnVerifySign.Size = new System.Drawing.Size(140, 27);
            this.btnVerifySign.TabIndex = 22;
            this.btnVerifySign.Text = "12) Verify Signature";
            this.btnVerifySign.UseVisualStyleBackColor = true;
            this.btnVerifySign.Click += new System.EventHandler(this.btnVerifySign_Click);
            // 
            // btnEncryptAndSign
            // 
            this.btnEncryptAndSign.Location = new System.Drawing.Point(327, 137);
            this.btnEncryptAndSign.Name = "btnEncryptAndSign";
            this.btnEncryptAndSign.Size = new System.Drawing.Size(164, 27);
            this.btnEncryptAndSign.TabIndex = 24;
            this.btnEncryptAndSign.Text = "Extra) EncryptAndSign";
            this.btnEncryptAndSign.UseVisualStyleBackColor = true;
            this.btnEncryptAndSign.Click += new System.EventHandler(this.btnEncryptAndSign_Click);
            // 
            // btnVerifyAndDecrypt
            // 
            this.btnVerifyAndDecrypt.Location = new System.Drawing.Point(508, 137);
            this.btnVerifyAndDecrypt.Name = "btnVerifyAndDecrypt";
            this.btnVerifyAndDecrypt.Size = new System.Drawing.Size(141, 27);
            this.btnVerifyAndDecrypt.TabIndex = 26;
            this.btnVerifyAndDecrypt.Text = "Extra) Verify and Decrypt";
            this.btnVerifyAndDecrypt.UseVisualStyleBackColor = true;
            this.btnVerifyAndDecrypt.Click += new System.EventHandler(this.btnVerifyAndDecrypt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(493, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "->";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 434);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnVerifyAndDecrypt);
            this.Controls.Add(this.btnDecryptFromStore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSignatureWithData);
            this.Controls.Add(this.btnDecryptFromPFX);
            this.Controls.Add(this.btnEncryptAndSign);
            this.Controls.Add(this.btnSignature);
            this.Controls.Add(this.btnEncryptStore);
            this.Controls.Add(this.btnVerifySignWithData);
            this.Controls.Add(this.btnEncryptCER);
            this.Controls.Add(this.btnVerifySign);
            this.Controls.Add(this.btnImportPrivateCert);
            this.Controls.Add(this.btnImportPublicCert);
            this.Controls.Add(this.btnExportPrivateCert);
            this.Controls.Add(this.btnExportPublicCert);
            this.Controls.Add(this.btnAddToStoreCER);
            this.Controls.Add(this.btnVerifyCertChain);
            this.Controls.Add(this.btnVerifyCert);
            this.Controls.Add(this.btnOpenFromStore);
            this.Controls.Add(this.btnOpenCER);
            this.Controls.Add(this.btnOpenPFX);
            this.Controls.Add(this.txtInfo);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Manipulação de certificados";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnOpenPFX;
        private System.Windows.Forms.Button btnOpenCER;
        private System.Windows.Forms.Button btnOpenFromStore;
        private System.Windows.Forms.Button btnVerifyCert;
        private System.Windows.Forms.Button btnVerifyCertChain;
        private System.Windows.Forms.Button btnExportPublicCert;
        private System.Windows.Forms.Button btnImportPublicCert;
        private System.Windows.Forms.Button btnExportPrivateCert;
        private System.Windows.Forms.Button btnImportPrivateCert;
        private System.Windows.Forms.Button btnAddToStoreCER;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDecryptFromStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSignatureWithData;
        private System.Windows.Forms.Button btnDecryptFromPFX;
        private System.Windows.Forms.Button btnSignature;
        private System.Windows.Forms.Button btnEncryptStore;
        private System.Windows.Forms.Button btnVerifySignWithData;
        private System.Windows.Forms.Button btnEncryptCER;
        private System.Windows.Forms.Button btnVerifySign;
        private System.Windows.Forms.Button btnEncryptAndSign;
        private System.Windows.Forms.Button btnVerifyAndDecrypt;
        private System.Windows.Forms.Label label5;
    }
}

