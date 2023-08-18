using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Majors
{
    public class MajorRepository : IMajorRepository
    {
        public async Task<IEnumerable<Major>> GetAll()
        {
            using(var dbContext = new CourseManagementContext())
            {
                return await dbContext.Majors.ToListAsync();
            }
        }
    }
}
