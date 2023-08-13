using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public bool AbsentCheck { get; set; }
        public int? StudentId { get; set; }
        public int? SessionId { get; set; }

        public virtual Session? Session { get; set; }
        public virtual Student? Student { get; set; }
    }
}
