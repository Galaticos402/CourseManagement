using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        public async Task<IEnumerable<Room>> GetAll()
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Rooms.ToListAsync();
            }
        }
    }
}
