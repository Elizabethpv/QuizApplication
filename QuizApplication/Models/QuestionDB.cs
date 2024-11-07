using System.Data.SqlClient;
using System.Data;

namespace QuizApplication.Models
{
    public class QuestionDB
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IT4CQOE\SQLEXPRESS;Initial Catalog=QuizApplication-CoreProject;Integrated Security=True");
        public string Fn_GetQuestionId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GetMaxQuestionID", con);
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
        public string Fn_QuestionsReg(Questions qobj, int quesid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Questions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Question_Id", quesid);
                cmd.Parameters.AddWithValue("@QuestionText", qobj.QuestionText);
                cmd.Parameters.AddWithValue("@Ques_OPA", qobj.Ques_OPA);
                cmd.Parameters.AddWithValue("@Ques_OPB", qobj.Ques_OPB);
                cmd.Parameters.AddWithValue("@Ques_OPC", qobj.Ques_OPC);
                cmd.Parameters.AddWithValue("@Ques_OPD", qobj.Ques_OPD);
                cmd.Parameters.AddWithValue("@Correct_OP", qobj.Correct_OP);

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
        public List<Questions> Fn_ListQuestions()
        {
            var getdata = new List<Questions>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllQuestions", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
        public string Fn_UpdateQuestion(int id, Questions qobj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateQuestionWithID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@QuestionText", qobj.QuestionText);
                cmd.Parameters.AddWithValue("@Ques_OPA", qobj.Ques_OPA);
                cmd.Parameters.AddWithValue("@Ques_OPB", qobj.Ques_OPB);
                cmd.Parameters.AddWithValue("@Ques_OPC", qobj.Ques_OPC);
                cmd.Parameters.AddWithValue("@Ques_OPD", qobj.Ques_OPD);
                cmd.Parameters.AddWithValue("@Correct_OP", qobj.Correct_OP);

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
        public int Fn_DeleteQuestion(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteQuestionWithID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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
        public Questions Fn_ListQuestionswithID(int id)
        {
            var getdata = new Questions();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AllQuestionsWithId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                   getdata = new Questions
                    {
                        QuestionText = da["QuestionText"].ToString(),
                        Ques_OPA = da["Ques_OPA"].ToString(),
                        Ques_OPB = da["Ques_OPB"].ToString(),
                        Ques_OPC = da["Ques_OPC"].ToString(),
                        Ques_OPD = da["Ques_OPD"].ToString(),
                        Correct_OP = da["Correct_OP"].ToString(),
                    };
                   
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

        public string Fn_UpdateQuestionID()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateQuestionsID", con);
                cmd.CommandType = CommandType.StoredProcedure;            

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
    }
}
