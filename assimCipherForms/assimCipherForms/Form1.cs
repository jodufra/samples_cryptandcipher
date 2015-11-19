using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assimCipherForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bttn_generateKeys_Click(object sender, EventArgs e)
        {
            var rsa = new RSACryptoServiceProvider();

        }

        private void btn_savePublic_Click(object sender, EventArgs e)
        {

        }

        private void btn_savePrivateKey_Click(object sender, EventArgs e)
        {

        }

        private void btn_encryptSecret_Click(object sender, EventArgs e)
        {

        }

        private void btn_decryptSecret_Click(object sender, EventArgs e)
        {

        }
    }
}
