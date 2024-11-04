using System.Data.SqlClient;
using System.Data;

namespace QuizApplication.Models
{
    public class QuizActionDB
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IT4CQOE\SQLEXPRESS;Initial Catalog=QuizApplication-CoreProject;Integrated Security=True");

        public string Fn_GetQuestioncount()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MaxQuestionCount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                string reg = cmd.ExecuteScalar()?.ToString() ?? "0";
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
        public List<Questions> Fn_GetQuestionschoice(int id)
        {
            var getdata = new List<Questions>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AllQuestionsWithId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    var o = new Questions
                    {
                        Question_Id = Convert.ToInt32(da["Question_Id"]),
                        QuestionText = da["QuestionText"].ToString(),
                        Ques_OPA = da["Ques_OPA"].ToString(),
                        Ques_OPB = da["Ques_OPB"].ToString(),
                        Ques_OPC = da["Ques_OPC"].ToString(),
                        Ques_OPD = da["Ques_OPD"].ToString(),
                        Correct_OP = da["Correct_OP"].ToString(),
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

        public string Fn_Selectoptinsert(int id, string op)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_InsertSelectedotions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@selectedoption", op);

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
        public int Fn_DeleteSelectoption()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteSelectedotions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                int deleted = cmd.ExecuteNonQuery();
                con.Close();

                return deleted;
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
        public string Fn_AccessDBOption(int id)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SP_LoadSelectedotions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                string Userselecop = cmd.ExecuteScalar().ToString();
                con.Close();
                return Userselecop;
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
        public string Fn_Selectedoptioncount(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CountSelectOption", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                string count = cmd.ExecuteScalar()?.ToString() ?? "0";
                con.Close();
                return count;
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
        public string Fn_UpdateSelectedoption(int id, string op)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateSelectOption", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@selectedoption", op);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return ("Updated successfully");
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
        public string Fn_GetExistingOption(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GetExistiongSelectOption", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                string option = cmd.ExecuteScalar().ToString();
                con.Close();
                return option;
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
        public string Fn_FinalScore()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Finalscore", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                string final = cmd.ExecuteScalar().ToString();
                con.Close();

                return final;
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
        public string Fn_Scoreinsert(int studid,int score)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_PostScore", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@student_id", studid);
                cmd.Parameters.AddWithValue("@exam_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Quiz_score", score);             
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

