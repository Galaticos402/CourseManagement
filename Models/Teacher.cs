using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class Teacher : User
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
            Sessions = new HashSet<Session>();
            Major = new Major();
        }
        public Teacher(string teacherName, string email, string password, string phone, int majorId)
        {
            TeacherName = teacherName;
            Phone = phone;
            Email = email;
            Pwd = password;
            MajorId = majorId;

        }
        public int Id { get; set; }
        public string TeacherName { get; set; } = null!;
        public string? Phone { get; set; }
        public int MajorId { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual Major Major { get; set; }
    }
}
