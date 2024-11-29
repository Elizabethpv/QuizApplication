using System.ComponentModel.DataAnnotations;

namespace QuizApplication.Models
{
    public class StudentReg
    {
        public int Student_id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Stud_Name { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public string? Stud_DOB { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Stud_Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

    }
}
