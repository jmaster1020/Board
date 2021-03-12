using MemoEngine.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MemoEngine.Repositories
{
    public class UserRepository
    {
        // 공통으로 사용될 커넥션 개체
        private SqlConnection con;

        public UserRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=themiraclesoft.iptime.org,1533; Initial Catalog=TheMiracleSoft_Test; User id = TheMiracleSoft; Password = miracle9182!";
                /*\*WebConfigurationManager.ConnectionStrings[
              "ConnectionString"].ConnectionString;*/
        }

        public void AddUser(string userId, string password, string username, string email, string intro)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "WriteUsers";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Intro", intro);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public UserViewModel GetUserByUserId(string userId)
        {
            UserViewModel r = new UserViewModel();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select* From Users Where UserID = @UserID";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@UserID", userId);

            con.Open();
            IDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                r.Id = dr.GetInt32(0);
                r.UserId = dr.GetString(1);
                r.Password = dr.GetString(2);
                r.Username = dr.GetString(3);
                r.Email = dr.GetString(4);
                r.Intro = dr.GetString(5);
            }
            con.Close();

            return r;
        }

        public void ModifyUser(int uid, string userId, string password, string username, string email, string intro)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "ModifyUsers";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Intro", intro);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@UID", uid);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool IsCorrectUser(string userId, string password)
        {
            bool result = false;

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select* From Users "
              + " Where UserID = @UserID And Password = @Password";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = true; // 아이디와 암호가 맞는 데이터가 있구나…
            }
            dr.Close();
            con.Close();
            return result;
        }
    }
}