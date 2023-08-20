using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Slots
{
    public class SlotRepository : ISlotRepository
    {
        public async Task<IEnumerable<Slot>> GetAll()
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Slots.ToListAsync();
            }
        }
    }
}
