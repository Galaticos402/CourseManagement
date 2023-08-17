using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Courses = new HashSet<Course>();
        }

        public Semester(string semesterName, DateTime startDate, DateTime endDate)
        {
            this.SemesterName = semesterName;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public int Id { get; set; }
        public string SemesterName { get; set; } = null!;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
