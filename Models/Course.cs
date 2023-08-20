using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class Course
    {
        public Course()
        {
            Sessions = new HashSet<Session>();
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public Course(string courseName, int teacherId, int semesterId, int subjectId)
        {
            CourseName = courseName;
            TeacherId = teacherId;
            SemesterId = semesterId;
            SubjectId = subjectId;
        }

        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public int? TeacherId { get; set; }
        public int? SemesterId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Semester? Semester { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
