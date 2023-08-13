using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;
        public int? TeacherId { get; set; }
        public int? MajorId { get; set; }

        public virtual Major? Major { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
