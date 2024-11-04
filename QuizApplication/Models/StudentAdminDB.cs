using System.Data;
using System.Data.SqlClient;

namespace QuizApplication.Models
{
    public class StudentAdminDB
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IT4CQOE\SQLEXPRESS;Initial Catalog=QuizApplication-CoreProject;Integrated Security=True");
        public string Fn_Feedback(int studid, Feedback fobj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Feedback", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@student_id", studid);
                cmd.Parameters.AddWithValue("@Feedback_text",fobj.Feedback_text);
               

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
        public List<Score> Fn_ListStudentScore()
        {
            var getdata = new List<Score>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GetScore", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    var o = new Score
                    {
                        studentname = da["Stud_Name"].ToString(),
                        Date = Convert.ToDateTime(da["exam_date"]),
                        DOB = da["Stud_DOB"].ToString(),
                        Email = da["Stud_Email"].ToString(),
                        score = Convert.ToInt32(da["Quiz_score"]),
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
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
        public List<Feedback> Fn_ListFeedback()
        {
            var getdata = new List<Feedback>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Getfeedback", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    var o = new Feedback
                    {
                        feedbackid = Convert.ToInt32(da["Feedback_id"]),
                        Student_name = da["Stud_Name"].ToString(),
                        Feedback_text = da["Feedback_text"].ToString(),
                        Student_Email = da["Stud_Email"].ToString(),

                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
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
        public string Fn_Replay(int fid,Feedback robj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AdminReplay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",fid);
                cmd.Parameters.AddWithValue("@Response_text", robj.Response_text);


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
    }
}
