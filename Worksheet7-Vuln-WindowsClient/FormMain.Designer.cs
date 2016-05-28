namespace WindowsClient
{
    partial class FormMain
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
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnGetUsers = new System.Windows.Forms.Button();
            this.lboxUsers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetDescription = new System.Windows.Forms.Button();
            this.txtMyDescription = new System.Windows.Forms.TextBox();
            this.btnSetDescription = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSQLInjection = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSQLInjection = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVerifyFileTimestamp = new System.Windows.Forms.Button();
            this.btnSignFileTimestamp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReplayAttack = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnChooseCert = new System.Windows.Forms.Button();
            this.btnAssocCC = new System.Windows.Forms.Button();
            this.btnGetUsersCert = new System.Windows.Forms.Button();
            this.btnReadCC = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdNumber = new System.Windows.Forms.TextBox();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(16, 30);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(278, 20);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.Text = "si";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(16, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(278, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "123";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnGetUsers
            // 
            this.btnGetUsers.Location = new System.Drawing.Point(16, 98);
            this.btnGetUsers.Name = "btnGetUsers";
            this.btnGetUsers.Size = new System.Drawing.Size(278, 23);
            this.btnGetUsers.TabIndex = 4;
            this.btnGetUsers.Text = "Get Users";
            this.btnGetUsers.UseVisualStyleBackColor = true;
            this.btnGetUsers.Click += new System.EventHandler(this.btnGetUsers_Click);
            // 
            // lboxUsers
            // 
            this.lboxUsers.FormattingEnabled = true;
            this.lboxUsers.Location = new System.Drawing.Point(319, 30);
            this.lboxUsers.Name = "lboxUsers";
            this.lboxUsers.Size = new System.Drawing.Size(261, 134);
            this.lboxUsers.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Users";
            // 
            // btnGetDescription
            // 
            this.btnGetDescription.Location = new System.Drawing.Point(304, 165);
            this.btnGetDescription.Name = "btnGetDescription";
            this.btnGetDescription.Size = new System.Drawing.Size(260, 23);
            this.btnGetDescription.TabIndex = 7;
            this.btnGetDescription.Text = "Get Selected User Description";
            this.btnGetDescription.UseVisualStyleBackColor = true;
            this.btnGetDescription.Click += new System.EventHandler(this.btnGetDescription_Click);
            // 
            // txtMyDescription
            // 
            this.txtMyDescription.Location = new System.Drawing.Point(16, 154);
            this.txtMyDescription.Multiline = true;
            this.txtMyDescription.Name = "txtMyDescription";
            this.txtMyDescription.Size = new System.Drawing.Size(278, 80);
            this.txtMyDescription.TabIndex = 8;
            // 
            // btnSetDescription
            // 
            this.btnSetDescription.Location = new System.Drawing.Point(16, 240);
            this.btnSetDescription.Name = "btnSetDescription";
            this.btnSetDescription.Size = new System.Drawing.Size(278, 23);
            this.btnSetDescription.TabIndex = 9;
            this.btnSetDescription.Text = "Set My Description";
            this.btnSetDescription.UseVisualStyleBackColor = true;
            this.btnSetDescription.Click += new System.EventHandler(this.btnSetDescription_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(304, 199);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(536, 57);
            this.txtDescription.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtSQLInjection);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnSQLInjection);
            this.panel1.Controls.Add(this.btnGetDescription);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Location = new System.Drawing.Point(12, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 267);
            this.panel1.TabIndex = 11;
            // 
            // txtSQLInjection
            // 
            this.txtSQLInjection.Location = new System.Drawing.Point(580, 23);
            this.txtSQLInjection.Multiline = true;
            this.txtSQLInjection.Name = "txtSQLInjection";
            this.txtSQLInjection.Size = new System.Drawing.Size(260, 134);
            this.txtSQLInjection.TabIndex = 13;
            this.txtSQLInjection.Text = "si\'; UPDATE Users SET Password =\'UerGtHGihNM0HYwMY9DxooYmKhg=\' WHERE Login = \'adm" +
    "in";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(582, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "SQL Injection Query";
            // 
            // btnSQLInjection
            // 
            this.btnSQLInjection.Location = new System.Drawing.Point(580, 164);
            this.btnSQLInjection.Name = "btnSQLInjection";
            this.btnSQLInjection.Size = new System.Drawing.Size(260, 23);
            this.btnSQLInjection.TabIndex = 11;
            this.btnSQLInjection.Text = "Get Selected User Description (SQL Injection)";
            this.btnSQLInjection.UseVisualStyleBackColor = true;
            this.btnSQLInjection.Click += new System.EventHandler(this.btnSQLInjection_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnVerifyFileTimestamp);
            this.panel2.Controls.Add(this.btnSignFileTimestamp);
            this.panel2.Location = new System.Drawing.Point(12, 298);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(857, 67);
            this.panel2.TabIndex = 12;
            // 
            // btnVerifyFileTimestamp
            // 
            this.btnVerifyFileTimestamp.Location = new System.Drawing.Point(200, 20);
            this.btnVerifyFileTimestamp.Name = "btnVerifyFileTimestamp";
            this.btnVerifyFileTimestamp.Size = new System.Drawing.Size(166, 23);
            this.btnVerifyFileTimestamp.TabIndex = 1;
            this.btnVerifyFileTimestamp.Text = "Verify Signature and Timestamp";
            this.btnVerifyFileTimestamp.UseVisualStyleBackColor = true;
            this.btnVerifyFileTimestamp.Click += new System.EventHandler(this.btnSignVerifyTimestamp_Click);
            // 
            // btnSignFileTimestamp
            // 
            this.btnSignFileTimestamp.Location = new System.Drawing.Point(10, 20);
            this.btnSignFileTimestamp.Name = "btnSignFileTimestamp";
            this.btnSignFileTimestamp.Size = new System.Drawing.Size(166, 23);
            this.btnSignFileTimestamp.TabIndex = 0;
            this.btnSignFileTimestamp.Text = "Sign File with Timestamp";
            this.btnSignFileTimestamp.UseVisualStyleBackColor = true;
            this.btnSignFileTimestamp.Click += new System.EventHandler(this.btnSignFileTimestamp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "TSA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Cartão Cidadão";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnReplayAttack);
            this.panel3.Controls.Add(this.statusStrip);
            this.panel3.Controls.Add(this.btnChooseCert);
            this.panel3.Controls.Add(this.btnAssocCC);
            this.panel3.Controls.Add(this.btnGetUsersCert);
            this.panel3.Controls.Add(this.btnReadCC);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtFullName);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtNIF);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtIdNumber);
            this.panel3.Controls.Add(this.pbPhoto);
            this.panel3.Location = new System.Drawing.Point(12, 386);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(857, 200);
            this.panel3.TabIndex = 14;
            // 
            // btnReplayAttack
            // 
            this.btnReplayAttack.Location = new System.Drawing.Point(559, 85);
            this.btnReplayAttack.Name = "btnReplayAttack";
            this.btnReplayAttack.Size = new System.Drawing.Size(281, 23);
            this.btnReplayAttack.TabIndex = 12;
            this.btnReplayAttack.Text = "Get Users Certificado (Replay Attack)";
            this.btnReplayAttack.UseVisualStyleBackColor = true;
            this.btnReplayAttack.Click += new System.EventHandler(this.btnReplayAttack_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 176);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(855, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 17);
            this.lblStatus.Text = "toolStripStatusLabel1";
            // 
            // btnChooseCert
            // 
            this.btnChooseCert.Location = new System.Drawing.Point(364, 34);
            this.btnChooseCert.Name = "btnChooseCert";
            this.btnChooseCert.Size = new System.Drawing.Size(180, 23);
            this.btnChooseCert.TabIndex = 10;
            this.btnChooseCert.Text = "Escolher Certificado (CC/Store)";
            this.btnChooseCert.UseVisualStyleBackColor = true;
            this.btnChooseCert.Click += new System.EventHandler(this.btnChooseCert_Click);
            // 
            // btnAssocCC
            // 
            this.btnAssocCC.Location = new System.Drawing.Point(364, 59);
            this.btnAssocCC.Name = "btnAssocCC";
            this.btnAssocCC.Size = new System.Drawing.Size(180, 23);
            this.btnAssocCC.TabIndex = 9;
            this.btnAssocCC.Text = "Associar Certificado";
            this.btnAssocCC.UseVisualStyleBackColor = true;
            this.btnAssocCC.Click += new System.EventHandler(this.btnAssocCC_Click);
            // 
            // btnGetUsersCert
            // 
            this.btnGetUsersCert.Location = new System.Drawing.Point(364, 85);
            this.btnGetUsersCert.Name = "btnGetUsersCert";
            this.btnGetUsersCert.Size = new System.Drawing.Size(180, 23);
            this.btnGetUsersCert.TabIndex = 8;
            this.btnGetUsersCert.Text = "Get Users Certificado";
            this.btnGetUsersCert.UseVisualStyleBackColor = true;
            this.btnGetUsersCert.Click += new System.EventHandler(this.btnGetUsersCert_Click);
            // 
            // btnReadCC
            // 
            this.btnReadCC.Location = new System.Drawing.Point(364, 5);
            this.btnReadCC.Name = "btnReadCC";
            this.btnReadCC.Size = new System.Drawing.Size(180, 26);
            this.btnReadCC.TabIndex = 7;
            this.btnReadCC.Text = "Ler CC";
            this.btnReadCC.UseVisualStyleBackColor = true;
            this.btnReadCC.Click += new System.EventHandler(this.btnReadCC_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(127, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Nome";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(127, 113);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(417, 20);
            this.txtFullName.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "NIF";
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(127, 75);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(195, 20);
            this.txtNIF.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "CC";
            // 
            // txtIdNumber
            // 
            this.txtIdNumber.Location = new System.Drawing.Point(127, 37);
            this.txtIdNumber.Name = "txtIdNumber";
            this.txtIdNumber.Size = new System.Drawing.Size(195, 20);
            this.txtIdNumber.TabIndex = 1;
            // 
            // pbPhoto
            // 
            this.pbPhoto.Location = new System.Drawing.Point(10, 19);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(100, 116);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 587);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSetDescription);
            this.Controls.Add(this.txtMyDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lboxUsers);
            this.Controls.Add(this.btnGetUsers);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "WindowsClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnGetUsers;
        private System.Windows.Forms.ListBox lboxUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetDescription;
        private System.Windows.Forms.TextBox txtMyDescription;
        private System.Windows.Forms.Button btnSetDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnVerifyFileTimestamp;
        private System.Windows.Forms.Button btnSignFileTimestamp;
        private System.Windows.Forms.Button btnReadCC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIdNumber;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Button btnAssocCC;
        private System.Windows.Forms.Button btnGetUsersCert;
        private System.Windows.Forms.Button btnChooseCert;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TextBox txtSQLInjection;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSQLInjection;
        private System.Windows.Forms.Button btnReplayAttack;
    }
}

