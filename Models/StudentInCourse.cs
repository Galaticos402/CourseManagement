﻿using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class StudentInCourse
    {
        public int Id { get; set; }
        public string MajorName { get; set; } = null!;
        public bool? PassCheck { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}