namespace assimCipherForms
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
            this.bttn_generateKeys = new System.Windows.Forms.Button();
            this.text_publicKey = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_savePublic = new System.Windows.Forms.Button();
            this.btn_savePrivateKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.text_privatePublicKey = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_secretKeyToEncrypt = new System.Windows.Forms.TextBox();
            this.btn_encryptSecret = new System.Windows.Forms.Button();
            this.btn_decryptSecret = new System.Windows.Forms.Button();
            this.text_decryptedSecretKey = new System.Windows.Forms.TextBox();
            this.text_encryptedSecretKey = new System.Windows.Forms.RichTextBox();
            this.text_bitsCount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttn_generateKeys
            // 
            this.bttn_generateKeys.Location = new System.Drawing.Point(12, 12);
            this.bttn_generateKeys.Name = "bttn_generateKeys";
            this.bttn_generateKeys.Size = new System.Drawing.Size(257, 23);
            this.bttn_generateKeys.TabIndex = 0;
            this.bttn_generateKeys.Text = "1 - Generate Keys";
            this.bttn_generateKeys.UseVisualStyleBackColor = true;
            this.bttn_generateKeys.Click += new System.EventHandler(this.bttn_generateKeys_Click);
            // 
            // text_publicKey
            // 
            this.text_publicKey.Location = new System.Drawing.Point(12, 54);
            this.text_publicKey.Name = "text_publicKey";
            this.text_publicKey.Size = new System.Drawing.Size(729, 96);
            this.text_publicKey.TabIndex = 1;
            this.text_publicKey.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Public Key";
            // 
            // btn_savePublic
            // 
            this.btn_savePublic.Location = new System.Drawing.Point(519, 156);
            this.btn_savePublic.Name = "btn_savePublic";
            this.btn_savePublic.Size = new System.Drawing.Size(222, 23);
            this.btn_savePublic.TabIndex = 3;
            this.btn_savePublic.Text = "2 - Save Public Key";
            this.btn_savePublic.UseVisualStyleBackColor = true;
            this.btn_savePublic.Click += new System.EventHandler(this.btn_savePublic_Click);
            // 
            // btn_savePrivateKey
            // 
            this.btn_savePrivateKey.Location = new System.Drawing.Point(519, 389);
            this.btn_savePrivateKey.Name = "btn_savePrivateKey";
            this.btn_savePrivateKey.Size = new System.Drawing.Size(222, 23);
            this.btn_savePrivateKey.TabIndex = 6;
            this.btn_savePrivateKey.Text = "3 - Save Private/Public Key";
            this.btn_savePrivateKey.UseVisualStyleBackColor = true;
            this.btn_savePrivateKey.Click += new System.EventHandler(this.btn_savePrivateKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Private/Public Key";
            // 
            // text_privatePublicKey
            // 
            this.text_privatePublicKey.Location = new System.Drawing.Point(12, 203);
            this.text_privatePublicKey.Name = "text_privatePublicKey";
            this.text_privatePublicKey.Size = new System.Drawing.Size(729, 180);
            this.text_privatePublicKey.TabIndex = 4;
            this.text_privatePublicKey.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.text_bitsCount);
            this.panel1.Controls.Add(this.text_encryptedSecretKey);
            this.panel1.Controls.Add(this.btn_decryptSecret);
            this.panel1.Controls.Add(this.text_decryptedSecretKey);
            this.panel1.Controls.Add(this.btn_encryptSecret);
            this.panel1.Controls.Add(this.text_secretKeyToEncrypt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(15, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 183);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Secret Key to Encrypt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Encrypted Secret Key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nº bits:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Decrypted Secret Key";
            // 
            // text_secretKeyToEncrypt
            // 
            this.text_secretKeyToEncrypt.Location = new System.Drawing.Point(137, 23);
            this.text_secretKeyToEncrypt.Name = "text_secretKeyToEncrypt";
            this.text_secretKeyToEncrypt.Size = new System.Drawing.Size(374, 20);
            this.text_secretKeyToEncrypt.TabIndex = 12;
            // 
            // btn_encryptSecret
            // 
            this.btn_encryptSecret.Location = new System.Drawing.Point(517, 21);
            this.btn_encryptSecret.Name = "btn_encryptSecret";
            this.btn_encryptSecret.Size = new System.Drawing.Size(204, 23);
            this.btn_encryptSecret.TabIndex = 8;
            this.btn_encryptSecret.Text = "4 -  Encrypt Secret";
            this.btn_encryptSecret.UseVisualStyleBackColor = true;
            this.btn_encryptSecret.Click += new System.EventHandler(this.btn_encryptSecret_Click);
            // 
            // btn_decryptSecret
            // 
            this.btn_decryptSecret.Location = new System.Drawing.Point(517, 139);
            this.btn_decryptSecret.Name = "btn_decryptSecret";
            this.btn_decryptSecret.Size = new System.Drawing.Size(204, 23);
            this.btn_decryptSecret.TabIndex = 13;
            this.btn_decryptSecret.Text = "5 - Decrypt Secret";
            this.btn_decryptSecret.UseVisualStyleBackColor = true;
            this.btn_decryptSecret.Click += new System.EventHandler(this.btn_decryptSecret_Click);
            // 
            // text_decryptedSecretKey
            // 
            this.text_decryptedSecretKey.Location = new System.Drawing.Point(137, 141);
            this.text_decryptedSecretKey.Name = "text_decryptedSecretKey";
            this.text_decryptedSecretKey.Size = new System.Drawing.Size(374, 20);
            this.text_decryptedSecretKey.TabIndex = 14;
            // 
            // text_encryptedSecretKey
            // 
            this.text_encryptedSecretKey.Location = new System.Drawing.Point(137, 66);
            this.text_encryptedSecretKey.Name = "text_encryptedSecretKey";
            this.text_encryptedSecretKey.Size = new System.Drawing.Size(584, 54);
            this.text_encryptedSecretKey.TabIndex = 15;
            this.text_encryptedSecretKey.Text = "";
            // 
            // text_bitsCount
            // 
            this.text_bitsCount.Location = new System.Drawing.Point(74, 100);
            this.text_bitsCount.Name = "text_bitsCount";
            this.text_bitsCount.Size = new System.Drawing.Size(57, 20);
            this.text_bitsCount.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_savePrivateKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_privatePublicKey);
            this.Controls.Add(this.btn_savePublic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_publicKey);
            this.Controls.Add(this.bttn_generateKeys);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttn_generateKeys;
        private System.Windows.Forms.RichTextBox text_publicKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_savePublic;
        private System.Windows.Forms.Button btn_savePrivateKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox text_privatePublicKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox text_bitsCount;
        private System.Windows.Forms.RichTextBox text_encryptedSecretKey;
        private System.Windows.Forms.Button btn_decryptSecret;
        private System.Windows.Forms.TextBox text_decryptedSecretKey;
        private System.Windows.Forms.Button btn_encryptSecret;
        private System.Windows.Forms.TextBox text_secretKeyToEncrypt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

