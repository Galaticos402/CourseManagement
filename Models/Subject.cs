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

        public Subject(string subjectName, string code, int? majorId)
        {
            SubjectName = subjectName;
            MajorId = majorId;
            Code = code;
        }

        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;
        public int? MajorId { get; set; }
        public string Code { get; set; }

        public virtual Major? Major { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
