using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class Session
    {
        public Session()
        {
            Attendances = new HashSet<Attendance>();
        }
        
        public Session(int courseId, int teacherId, int roomId, int slotId, DateTime date) 
        {
            CourseId = courseId;
            RoomId = roomId;
            SlotId = slotId;
            Date = date;
            TeacherId = teacherId;
        }

        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public int? RoomId { get; set; }
        public int? SlotId { get; set; }
        public DateTime? Date {  get; set; }

        public virtual Course? Course { get; set; }
        public virtual Room? Room { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Slot? Slot { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
