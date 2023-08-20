using CourseManagement.Models;

namespace CourseManagement.Repository.Rooms
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAll(); 
    }
}
