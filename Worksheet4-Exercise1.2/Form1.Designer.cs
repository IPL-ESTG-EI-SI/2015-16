namespace Exercise1._2
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
            this.tbInput1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInput2 = new System.Windows.Forms.TextBox();
            this.btnInput1 = new System.Windows.Forms.Button();
            this.btnInput2 = new System.Windows.Forms.Button();
            this.btnFinal = new System.Windows.Forms.Button();
            this.tbInputFinal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHash = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Block 1 ";
            // 
            // tbInput1
            // 
            this.tbInput1.Location = new System.Drawing.Point(13, 30);
            this.tbInput1.Name = "tbInput1";
            this.tbInput1.Size = new System.Drawing.Size(202, 20);
            this.tbInput1.TabIndex = 1;
            this.tbInput1.Text = "Data.to.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Input Block 2";
            // 
            // tbInput2
            // 
            this.tbInput2.Location = new System.Drawing.Point(235, 29);
            this.tbInput2.Name = "tbInput2";
            this.tbInput2.Size = new System.Drawing.Size(204, 20);
            this.tbInput2.TabIndex = 3;
            this.tbInput2.Text = "Compute.";
            // 
            // btnInput1
            // 
            this.btnInput1.Location = new System.Drawing.Point(13, 57);
            this.btnInput1.Name = "btnInput1";
            this.btnInput1.Size = new System.Drawing.Size(202, 23);
            this.btnInput1.TabIndex = 4;
            this.btnInput1.Text = "SHA1-TransformBlock";
            this.btnInput1.UseVisualStyleBackColor = true;
            this.btnInput1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInput2
            // 
            this.btnInput2.Location = new System.Drawing.Point(235, 57);
            this.btnInput2.Name = "btnInput2";
            this.btnInput2.Size = new System.Drawing.Size(204, 23);
            this.btnInput2.TabIndex = 5;
            this.btnInput2.Text = "SHA1-TransformBlock";
            this.btnInput2.UseVisualStyleBackColor = true;
            this.btnInput2.Click += new System.EventHandler(this.btnInput2_Click);
            // 
            // btnFinal
            // 
            this.btnFinal.Location = new System.Drawing.Point(13, 145);
            this.btnFinal.Name = "btnFinal";
            this.btnFinal.Size = new System.Drawing.Size(202, 23);
            this.btnFinal.TabIndex = 8;
            this.btnFinal.Text = "SHA1-TransformFinalBlock";
            this.btnFinal.UseVisualStyleBackColor = true;
            this.btnFinal.Click += new System.EventHandler(this.btnFinal_Click);
            // 
            // tbInputFinal
            // 
            this.tbInputFinal.Location = new System.Drawing.Point(13, 118);
            this.tbInputFinal.Name = "tbInputFinal";
            this.tbInputFinal.Size = new System.Drawing.Size(202, 20);
            this.tbInputFinal.TabIndex = 7;
            this.tbInputFinal.Text = "Hash";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last Input Block ";
            // 
            // tbHash
            // 
            this.tbHash.Location = new System.Drawing.Point(235, 118);
            this.tbHash.Multiline = true;
            this.tbHash.Name = "tbHash";
            this.tbHash.Size = new System.Drawing.Size(202, 50);
            this.tbHash.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hash (HEX)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 189);
            this.Controls.Add(this.tbHash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFinal);
            this.Controls.Add(this.tbInputFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInput2);
            this.Controls.Add(this.btnInput1);
            this.Controls.Add(this.tbInput2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbInput1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInput1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInput2;
        private System.Windows.Forms.Button btnInput1;
        private System.Windows.Forms.Button btnInput2;
        private System.Windows.Forms.Button btnFinal;
        private System.Windows.Forms.TextBox tbInputFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHash;
        private System.Windows.Forms.Label label4;
    }
}

