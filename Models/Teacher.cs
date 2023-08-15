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
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string TeacherName { get; set; } = null!;
        public int? Phone { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
