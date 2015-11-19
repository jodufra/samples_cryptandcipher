namespace digitalsignforms
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSignHash = new System.Windows.Forms.Button();
            this.btnSignData = new System.Windows.Forms.Button();
            this.btnVerifyHash = new System.Windows.Forms.Button();
            this.btnVerifyData = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(729, 20);
            this.textBox1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 141);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(729, 215);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // btnSignHash
            // 
            this.btnSignHash.Location = new System.Drawing.Point(13, 40);
            this.btnSignHash.Name = "btnSignHash";
            this.btnSignHash.Size = new System.Drawing.Size(75, 23);
            this.btnSignHash.TabIndex = 3;
            this.btnSignHash.Text = "Sign hash";
            this.btnSignHash.UseVisualStyleBackColor = true;
            this.btnSignHash.Click += new System.EventHandler(this.btnSignHash_Click);
            // 
            // btnSignData
            // 
            this.btnSignData.Location = new System.Drawing.Point(667, 40);
            this.btnSignData.Name = "btnSignData";
            this.btnSignData.Size = new System.Drawing.Size(75, 23);
            this.btnSignData.TabIndex = 4;
            this.btnSignData.Text = "button2";
            this.btnSignData.UseVisualStyleBackColor = true;
            this.btnSignData.Click += new System.EventHandler(this.btnSignData_Click);
            // 
            // btnVerifyHash
            // 
            this.btnVerifyHash.Location = new System.Drawing.Point(12, 362);
            this.btnVerifyHash.Name = "btnVerifyHash";
            this.btnVerifyHash.Size = new System.Drawing.Size(75, 23);
            this.btnVerifyHash.TabIndex = 5;
            this.btnVerifyHash.Text = "button3";
            this.btnVerifyHash.UseVisualStyleBackColor = true;
            this.btnVerifyHash.Click += new System.EventHandler(this.btnVerifyHash_Click);
            // 
            // btnVerifyData
            // 
            this.btnVerifyData.Location = new System.Drawing.Point(667, 362);
            this.btnVerifyData.Name = "btnVerifyData";
            this.btnVerifyData.Size = new System.Drawing.Size(75, 23);
            this.btnVerifyData.TabIndex = 6;
            this.btnVerifyData.Text = "button4";
            this.btnVerifyData.UseVisualStyleBackColor = true;
            this.btnVerifyData.Click += new System.EventHandler(this.btnVerifyData_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(13, 69);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(728, 66);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 398);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.btnVerifyData);
            this.Controls.Add(this.btnVerifyHash);
            this.Controls.Add(this.btnSignData);
            this.Controls.Add(this.btnSignHash);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSignHash;
        private System.Windows.Forms.Button btnSignData;
        private System.Windows.Forms.Button btnVerifyHash;
        private System.Windows.Forms.Button btnVerifyData;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

