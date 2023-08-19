using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly int itemPerPage = 10;
        public async Task<IEnumerable<Course>> GetCoursesByPageNumber(int page)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Courses.Skip(itemPerPage * (page - 1)).Take(itemPerPage).ToListAsync();
            }
        }
    }
}
