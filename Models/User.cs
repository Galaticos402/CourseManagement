using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Models
{
    public class User
    {
        [Required]
        [RegularExpression("^([a-zA-Z0-9]+)([\\.{1}])?([a-zA-Z0-9]+)\\@gmail([\\.])com$", ErrorMessage = "Invalid Email address")]
        public virtual string Email { get; set; } = null!;
        [Required]
        public string Pwd { get; set; } = null!;
    }
}
