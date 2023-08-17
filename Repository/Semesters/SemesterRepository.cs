using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CourseManagement.Repository.Semesters
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly int itemPerPage = 10;

        public async Task<HttpStatusCode> Create(Semester semester)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    dbContext.Semesters.Add(semester);
                    await dbContext.SaveChangesAsync();
                    return HttpStatusCode.Created;
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.BadRequest;
                }
            }
        }

        public async Task<IEnumerable<Semester>> GetSemestersByPageNumber(int page)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Semesters.Skip(itemPerPage * (page - 1)).ToListAsync();
            }
        }
    }
}
