using MemoEngine.Repositories;
using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MemoEngine.login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static class EncryptionHelper
        {
            public static string Encrypt(string txtPassword)
            {
                string EncryptionKey = "abc123";
                byte[] clearBytes = Encoding.Unicode.GetBytes(txtPassword);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        txtPassword = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return txtPassword;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string encPassword = EncryptionHelper.Encrypt(txtPassword.Text);
            var userRepo = new UserRepository();
            if (userRepo.IsCorrectUser(txtUserID.Text, encPassword))
            {

                //[!] 인증 부여
                if (!string.IsNullOrEmpty(txtUserID.Text) &&
                    (!string.IsNullOrEmpty(encPassword)))

                {
                    // 인증 쿠키값 부여
                    FormsAuthentication.RedirectFromLoginPage(txtUserID.Text, false);
                }
                else
                {
                    // 인증 쿠키값 부여
                    FormsAuthentication.SetAuthCookie(txtUserID.Text, false);
                    Response.Redirect("/DotNetNote/Default.aspx");

                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(
                  this.GetType(), "showMsg",
                  "<script>alert('잘못된 사용자입니다.');</script>");
            }

            Response.Cookies["Password"].Value = txtPassword.Text;
            Response.Cookies["UserID"].Value = txtUserID.Text;
        }
    }
}






