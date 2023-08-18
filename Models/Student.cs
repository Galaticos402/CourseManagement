using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class Student : User
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public Student(string studentName, string email, string passwrod, string phone, int majorId)
        {
            StudentName = studentName;
            Phone = phone;
            Email = email;
            Pwd = passwrod;
            MajorId = majorId;

        }
        

        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public string Phone { get; set; }
        public int MajorId { get; set; }

        public virtual Major Major { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
