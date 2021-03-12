using MemoEngine.Repositories;
using System;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;

namespace MemoEngine.login
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = themiraclesoft.iptime.org, 1533; Initial Catalog = TheMiracleSoft_Test; User id = TheMiracleSoft; Password = miracle9182!";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Users Where UserID = @UserID";
            cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();


            if (rd.HasRows)
            { 
                Label1.Visible = true;
                Label1.Text = "사용중인 아이디입니다";
                Label1.ForeColor = System.Drawing.Color.Red;
               /* string strJs =
             "<script> alert('사용중인 아이디 입니다. \\n다시 입력하세요');location.href='/login/Register.aspx';</script>";
                Page.ClientScript.RegisterClientScriptBlock(
                    this.GetType(), "goRegiser", strJs);*/

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "사용할 수 있는 아이디입니다.";
                Label1.ForeColor = System.Drawing.Color.Green;
                
            }


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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string encPassword = EncryptionHelper.Encrypt(txtPassword.Text);
            // 데이터 저장
            var userRepo = new UserRepository();
            userRepo.AddUser(txtUserID.Text, encPassword, txtUserName.Text, txtEmail.Text, txtIntro.Text);

            // 메시지 박스 출력후 기본 페이지 이동
            string strJs =
                "<script> alert('가입완료');location.href='/Default.aspx';</script>";
            Page.ClientScript.RegisterClientScriptBlock(
                this.GetType(), "goDefault", strJs);

        }
    }
}