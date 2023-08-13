using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public int MajorId { get; set; }

        public virtual Major Major { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
