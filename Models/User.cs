namespace CourseManagement.Models
{
    public class User
    {
        public virtual string Email { get; set; } = null!;
        public string Pwd { get; set; } = null!;
    }
}
