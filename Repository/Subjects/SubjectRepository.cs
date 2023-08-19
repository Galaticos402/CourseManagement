using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CourseManagement.Repository.Subjects
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly int itemPerPage = 10;
        public async Task<Subject?> Get(int subjectId)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Subjects.FindAsync(subjectId);
            }
        }


        public async Task<HttpStatusCode> Create(Subject subject)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    dbContext.Subjects.Add(subject);
                    await dbContext.SaveChangesAsync();
                    return HttpStatusCode.Created;
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.BadRequest;
                }

            }
        }

        public async Task<IEnumerable<Subject>> GetByPageNumber(int page = 1)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Subjects.Skip(itemPerPage * (page - 1)).Take(itemPerPage).Include(std => std.Major).ToListAsync();
            };
        }

        public async Task<HttpStatusCode> Update(Subject subject)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    var existedSubject = await Get(subject.Id);
                    if (existedSubject != null)
                    {
                        dbContext.Entry<Subject>(existedSubject).CurrentValues.SetValues(subject);
                        dbContext.Entry(existedSubject).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                        return HttpStatusCode.OK;
                    }
                    else
                    {
                        return HttpStatusCode.BadRequest;
                    }
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.BadGateway;
                }
            }
        }
    }
}
