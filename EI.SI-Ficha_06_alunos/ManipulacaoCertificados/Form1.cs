using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs; // precisa de se adicionar a assembly: System.Security (neste projecto já está adicionada)
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace ManipulacaoCertificados
{
    public partial class Form1 : Form
    {
        // os respectivos certificados deverão ser colocados directoria: /bin/debug
        const string filePFXCert = @"estg.dei.si.a.pfx";
        const string fileCERCert = @"estg.dei.si.a.cer";
        static readonly string pwdfilePFXCert = Properties.Settings.Default.PwdPFX;

        private byte[] tempRawCert = null;
        private byte[] tempData = null;
        private byte[] tempSignature = null;
        private byte[] tempEnvelope = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        // Mostrar informação de um certificado
        private void ShowCertificate(X509Certificate2 cert)
        {
            String text = "";
            text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            text += "cert:Version: " + cert.Version + Environment.NewLine;
            text += "Subject: " + cert.Subject + Environment.NewLine;
            text += "FriendlyName: " + cert.FriendlyName + Environment.NewLine;
            text += "IssuerName: " + cert.IssuerName + Environment.NewLine;
            text += "cert:NotBefore: " + cert.NotBefore + Environment.NewLine;
            text += "cert:NotAfter: " + cert.NotAfter + Environment.NewLine;
            text += "cert:HasPrivateKey: " + cert.HasPrivateKey + Environment.NewLine;
            text += "cert:PublicKey: " + cert.GetPublicKeyString() + Environment.NewLine;
            text += "cert:KeyAlgorithm: " + cert.GetKeyAlgorithm() + Environment.NewLine;
            text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            text += Environment.NewLine;
            txtInfo.Text = text + txtInfo.Text;
        }

        private void ShowMessage(String message)
        {
            String text = "";
            text += message + Environment.NewLine;
            text += Environment.NewLine;
            txtInfo.Text = text + txtInfo.Text;
        }

        private void btnOpenPFX_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);
                ShowCertificate(cert);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void btnOpenCER_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(fileCERCert);
                ShowCertificate(cert);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void btnOpenFromStore_Click(object sender, EventArgs e)
        { 
            try
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(store.Certificates, "Certificates", "Choose one certificate", X509SelectionFlag.SingleSelection);
                if (certs.Count > 0)
                {
                    X509Certificate2UI.DisplayCertificate(certs[0]);
                    ShowCertificate(certs[0]);
                }
                else
                {
                    ShowMessage("No certificate selected");
                }
                store.Close();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }


        private void btnVerifyCert_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(fileCERCert);
                ShowMessage(cert.Verify() ? "Certificate Valid" : "Certificate Invalid");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void btnVerifyCertChain_Click(object sender, EventArgs e)
        {

        }

        private void btnExportPublicCert_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(fileCERCert);
                byte[] cExport = cert.Export(X509ContentType.Cert);
                File.WriteAllBytes("certificate.cer", cExport);
                ShowMessage("Certificate exported as certificate.cer");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void btnExportPrivateCert_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert, X509KeyStorageFlags.Exportable);
                byte[] cExport = cert.Export(X509ContentType.Pfx, pwdfilePFXCert);
                File.WriteAllBytes("certificate.pfx", cExport);
                ShowMessage("Certificate exported as certificate.pfx");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void btnImportPublicCert_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2();
                cert.Import(File.ReadAllBytes("certificate.cer"));
                ShowCertificate(cert);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void btnImportPrivateCert_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2();
                cert.Import(File.ReadAllBytes("certificate.pfx"), pwdfilePFXCert, X509KeyStorageFlags.DefaultKeySet);
                ShowCertificate(cert);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void btnAddToStoreCER_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2();
                cert.Import(File.ReadAllBytes("certificate.cer"));
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadWrite);
                store.Add(cert);
                ShowMessage("certificate.cer added to Store");
                store.Close();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        //Right side
        private void btnSignatureWithData_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(txtInfo.Text);
                ContentInfo info = new ContentInfo(data);

                X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);
                CmsSigner signer = new CmsSigner(cert);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void btnVerifySignWithData_Click(object sender, EventArgs e)
        {

        }

        private void btnSignature_Click(object sender, EventArgs e)
        {

        }

        private void btnVerifySign_Click(object sender, EventArgs e)
        {

        }

        private void btnEncryptCER_Click(object sender, EventArgs e)
        {

        }

        private void btnDecryptFromPFX_Click(object sender, EventArgs e)
        {

        }

        private void btnEncryptStore_Click(object sender, EventArgs e)
        {

        }

        private void btnDecryptFromStore_Click(object sender, EventArgs e)
        {

        }




        private void btnEncryptAndSign_Click(object sender, EventArgs e)
        {

        }

        private void btnVerifyAndDecrypt_Click(object sender, EventArgs e)
        {

        }

    }
}