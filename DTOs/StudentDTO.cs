namespace CourseManagement.DTOs
{
    public class StudentDTO
    {
        public string StudentName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public int MajorId { get; set; }
    }
}
