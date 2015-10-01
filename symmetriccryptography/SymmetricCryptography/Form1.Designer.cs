namespace SymmetricCryptography
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
            this.tb_toEncrypt = new System.Windows.Forms.TextBox();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.btn_dencrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_toDencrypt = new System.Windows.Forms.RichTextBox();
            this.tb_dencrypted = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            // tb_toEncrypt
            // 
            this.tb_toEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_toEncrypt.Location = new System.Drawing.Point(13, 30);
            this.tb_toEncrypt.Name = "tb_toEncrypt";
            this.tb_toEncrypt.Size = new System.Drawing.Size(536, 20);
            this.tb_toEncrypt.TabIndex = 1;
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_encrypt.Location = new System.Drawing.Point(112, 56);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(350, 23);
            this.btn_encrypt.TabIndex = 2;
            this.btn_encrypt.Text = "Encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // btn_dencrypt
            // 
            this.btn_dencrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dencrypt.Location = new System.Drawing.Point(112, 212);
            this.btn_dencrypt.Name = "btn_dencrypt";
            this.btn_dencrypt.Size = new System.Drawing.Size(354, 23);
            this.btn_dencrypt.TabIndex = 5;
            this.btn_dencrypt.Text = "Decrypt";
            this.btn_dencrypt.UseVisualStyleBackColor = true;
            this.btn_dencrypt.Click += new System.EventHandler(this.btn_dencrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Encrypted Text (UTF-8)";
            // 
            // tb_toDencrypt
            // 
            this.tb_toDencrypt.Location = new System.Drawing.Point(10, 110);
            this.tb_toDencrypt.Name = "tb_toDencrypt";
            this.tb_toDencrypt.Size = new System.Drawing.Size(261, 96);
            this.tb_toDencrypt.TabIndex = 6;
            this.tb_toDencrypt.Text = "";
            // 
            // tb_dencrypted
            // 
            this.tb_dencrypted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_dencrypted.Location = new System.Drawing.Point(13, 264);
            this.tb_dencrypted.Name = "tb_dencrypted";
            this.tb_dencrypted.Size = new System.Drawing.Size(536, 20);
            this.tb_dencrypted.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Decrypted Text";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(277, 110);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(272, 96);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Encrypted Text (UTF-8)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 301);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_dencrypted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_toDencrypt);
            this.Controls.Add(this.btn_dencrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_encrypt);
            this.Controls.Add(this.tb_toEncrypt);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_toEncrypt;
        private System.Windows.Forms.Button btn_encrypt;
        private System.Windows.Forms.Button btn_dencrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tb_toDencrypt;
        private System.Windows.Forms.TextBox tb_dencrypted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
    }
}

