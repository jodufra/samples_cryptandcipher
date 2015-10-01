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

namespace SymmetricCryptography
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            String toEncrypt = tb_toEncrypt.Text;

            if (String.IsNullOrEmpty(toEncrypt)) return;

            AesCryptoServiceProvider aes = null;
            try
            {
                aes = new AesCryptoServiceProvider();
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                if (aes != null) aes.Dispose();
            }


        }

        private void btn_dencrypt_Click(object sender, EventArgs e)
        {

        }
    }
}
