using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymmetricCryptography
{
    public partial class Form1 : Form
    {
        byte[] iv;
        byte[] key;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            String toEncrypt = tb_toEncrypt.Text;

            if (String.IsNullOrEmpty(toEncrypt)) return;

            AesCryptoServiceProvider aes = null;
            MemoryStream ms = null;
            CryptoStream cs = null;
            try
            {
                var data = Encoding.UTF8.GetBytes(toEncrypt);
                aes = new AesCryptoServiceProvider();
                iv = aes.IV;
                key = aes.Key;
                ms = new MemoryStream();
                cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(data, 0, data.Length);
                cs.Flush();
                if (!cs.HasFlushedFinalBlock)
                    cs.FlushFinalBlock();
                cs.Close();

                var encrypted = ms.ToArray();

                tb_toDencryptUTF8.Text = Encoding.UTF8.GetString(encrypted);
                tb_toDencryptB64.Text = Convert.ToBase64String(encrypted);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (aes != null) aes.Dispose();
                if (cs != null) cs.Dispose();
                if (ms != null) ms.Dispose();
            }


        }

        private void btn_dencrypt_Click(object sender, EventArgs e)
        {

            String toDecrypt = tb_toDencryptUTF8.Text;

            if (String.IsNullOrEmpty(toDecrypt)) return;

            AesCryptoServiceProvider aes = null;
            MemoryStream ms = null;
            CryptoStream cs = null;
            try
            {
                aes = new AesCryptoServiceProvider();
                aes.Key = key;
                aes.IV = iv;

                var encrypted = Convert.FromBase64String(tb_toDencryptB64.Text);
                ms = new MemoryStream(encrypted);
                cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);

                byte[] buffer = new byte[encrypted.Length];
                int offset = cs.Read(buffer, 0, buffer.Length);

                tb_dencrypted.Text = Encoding.UTF8.GetString(buffer, 0, offset);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (aes != null) aes.Dispose();
                if (cs != null) cs.Dispose();
                if (ms != null) ms.Dispose();
            }
        }
    }
}
