using System.ComponentModel.DataAnnotations;

namespace QuizApplication.Models
{
    public class AdminReg
    {
        public int Admin_id {get;set;}
        [Required(ErrorMessage = "Name is required")]
        public string? Admin_Name { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime Admin_DOB   {get;set;}
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Admin_Email {get;set;}
        [Required(ErrorMessage = "Username is required")]
        public string? Admin_Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Admin_Password { get; set; }

        public int reg_ids { get; set; }

    }
}
