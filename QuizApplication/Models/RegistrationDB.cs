
using System.Data;
using System.Data.SqlClient;

namespace QuizApplication.Models
{
    public class RegistrationDB
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IT4CQOE\SQLEXPRESS;Initial Catalog=QuizApplication-CoreProject;Integrated Security=True");


        public string Fn_GetRegId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GetMaxRegID", con);
                cmd.CommandType = CommandType.StoredProcedure;               
                con.Open();
                string reg= cmd.ExecuteScalar()?.ToString() ?? "0";
                con.Close();
                return reg;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }

        }
        public string Fn_AdiminReg(AdminReg adobj,int maxregid)
        {          
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AdminReg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Admin_id", maxregid); 
                cmd.Parameters.AddWithValue("@Admin_Name", adobj.Admin_Name);
                cmd.Parameters.AddWithValue("@Admin_DOB", adobj.Admin_DOB);
                cmd.Parameters.AddWithValue("@Admin_Email", adobj.Admin_Email);
                cmd.Parameters.AddWithValue("@Reg_Id", maxregid);
                cmd.Parameters.AddWithValue("@Username", adobj.Admin_Username);
                cmd.Parameters.AddWithValue("@Password", adobj.Admin_Password);
                cmd.Parameters.AddWithValue("@Logtype", "admin");

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return ("Inserted successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }
        public string Fn_StudentReg(StudentReg sdobj, int maxregid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_StudentReg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_id", maxregid);
                cmd.Parameters.AddWithValue("@Stud_Name", sdobj.Stud_Name);
                cmd.Parameters.AddWithValue("@Stud_DOB", sdobj.Stud_DOB);
                cmd.Parameters.AddWithValue("@Stud_Email", sdobj.Stud_Email);
                cmd.Parameters.AddWithValue("@Reg_Id", maxregid);
                cmd.Parameters.AddWithValue("@Username", sdobj.Username);
                cmd.Parameters.AddWithValue("@Password", sdobj.Password);
                cmd.Parameters.AddWithValue("@Logtype", "student");

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return ("Inserted successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }

        public string Fn_Login(Login ldobj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username",ldobj.Username);
                cmd.Parameters.AddWithValue("@password",ldobj.Password);
              
                con.Open();
                string count=cmd.ExecuteScalar().ToString();
                con.Close();

                return count;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }
        public string Fn_LoginType(Login ldobj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_LoginType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", ldobj.Username);
                cmd.Parameters.AddWithValue("@password", ldobj.Password);

                con.Open();
                string Usertype = cmd.ExecuteScalar().ToString();
                con.Close();

                return Usertype;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }
        public string Fn_LoginID(Login ldobj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GetStudentId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", ldobj.Username);
                cmd.Parameters.AddWithValue("@password", ldobj.Password);

                con.Open();
                string Userid = cmd.ExecuteScalar().ToString();
                con.Close();

                return Userid;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }


    }
}
