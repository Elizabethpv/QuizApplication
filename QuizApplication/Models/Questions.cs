namespace QuizApplication.Models
{
    public class Questions
    {
        public int Question_Id { get; set; }
        public string? QuestionText { get; set; }
        public string? Ques_OPA { get; set; }
        public string? Ques_OPB { get; set; }
        public string? Ques_OPC { get; set; }
        public string? Ques_OPD { get; set; }
        public string? Correct_OP { get; set; }
        public string? Selected_OP { get; set; }      
        public string? DB_Access_OP { get; set; }
    }  
    
}
