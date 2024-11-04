namespace QuizApplication.Models
{
    public class AdminReg
    {
        public int Admin_id {get;set;}
        public string? Admin_Name { get; set; }
        public DateTime Admin_DOB   {get;set;}
        public string? Admin_Email {get;set;}
        public string? Admin_Username { get; set; }
        public string? Admin_Password { get; set; }

        public int reg_ids { get; set; }

    }
}
