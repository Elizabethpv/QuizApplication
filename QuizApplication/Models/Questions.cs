using System.ComponentModel.DataAnnotations;

namespace QuizApplication.Models
{
    public class Questions
    {
        public int Question_Id { get; set; }
        [Required(ErrorMessage = "Question is required")]
        public string? QuestionText { get; set; }
        [Required(ErrorMessage = "OptionA is required")]
        public string? Ques_OPA { get; set; }
        [Required(ErrorMessage = "OptionB is required")]
        public string? Ques_OPB { get; set; }
        [Required(ErrorMessage = "OptionC is required")]
        public string? Ques_OPC { get; set; }
        [Required(ErrorMessage = "OptionD is required")]
        public string? Ques_OPD { get; set; }
        [Required(ErrorMessage = "Correct Option is required")]
        public string? Correct_OP { get; set; }
        public string? Selected_OP { get; set; }      
        public string? DB_Access_OP { get; set; }
    }  
    
}
