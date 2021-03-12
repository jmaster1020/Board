using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.login
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/login/Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                DisplayData();
            }

        }

        private void DisplayData()
        {
            UserRepository userRepo = new UserRepository();
            var model = userRepo.GetUserByUserId(Page.User.Identity.Name);

            lblUID.Text = model.Id.ToString();
            txtUserID.Text = model.UserId;
            txtPassword.Text = model.Password;
            txtEmail.Text = model.Email;
            txtUserName.Text = model.Username;
            txtIntro.Text = model.Intro;
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

        protected void btnModify_Click(object sender, EventArgs e)
        {
            // 데이터 수정
            string encPassword = EncryptionHelper.Encrypt(txtPassword.Text);
            var userRepo = new UserRepository();
            userRepo.ModifyUser(
                Convert.ToInt32(lblUID.Text), txtUserID.Text, encPassword, txtUserName.Text, txtEmail.Text, txtIntro.Text);

            // 메세지 박스 출력 후 기본 페이지로 이동
            string strJs =
                "<script>alert('수정완료');location.href='/DotNetNote/Default.aspx';</script>";
            Page.ClientScript.RegisterClientScriptBlock(
                this.GetType(), "goDefault", strJs);
        }
    }
}