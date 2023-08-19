using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
            Subjects = new HashSet<Subject>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string? MajorName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
