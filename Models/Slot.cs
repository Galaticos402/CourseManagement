namespace CourseManagement.Models
{
    public partial class Slot
    {
        public Slot() {
            Sessions = new HashSet<Session>();
        }
        public int Id { get; set; }
        public string SlotNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
