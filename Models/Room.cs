using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public partial class Room
    {
        public Room()
        {
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string RoomNumber { get; set; } = null!;

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
