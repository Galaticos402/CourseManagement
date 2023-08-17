using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Models
{
    public partial class Admin : User
    {
        [Key]
        public override string Email { get; set; } = null!;
    }
}
