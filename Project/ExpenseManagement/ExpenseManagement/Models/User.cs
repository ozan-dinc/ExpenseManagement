using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter Firstname")]
        [MinLength(3, ErrorMessage = "The name too short 3")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Lastname")]
        [MinLength(3, ErrorMessage = "The Lastname too short 3")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address")]
        [MinLength(3, ErrorMessage = "The Email Address too short 3")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

    }
}
