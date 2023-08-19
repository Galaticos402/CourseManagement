using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CourseManagement.Repository.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly int itemPerPage = 10;
        public async Task<HttpStatusCode> Create(Teacher teacher)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    dbContext.Teachers.Add(teacher);
                    await dbContext.SaveChangesAsync();
                    return HttpStatusCode.Created;
                }
                catch (Exception e)
                {
                    return HttpStatusCode.BadRequest;
                }

            }
        }

        public async Task<HttpStatusCode> Delete(int teacherId)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    var teacher = Get(teacherId);
                    if (teacher != null)
                    {
                        dbContext.Teachers.Remove(teacher);
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

        public Teacher? Get(int teacherId)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return dbContext.Teachers.Find(teacherId);
            }
        }

        public Teacher? GetByEmailAndPassword(string email, string password)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return dbContext.Teachers.Where(teacher => teacher.Email.Equals(email) && teacher.Pwd.Equals(password)).FirstOrDefault();
            }
        }
        public async Task<IEnumerable<Teacher>> GetByPageNumber(int page)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Teachers.Skip(itemPerPage * (page - 1)).Take(itemPerPage).ToListAsync();
            }
        }
        public async Task<HttpStatusCode> Update(Teacher teacher)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    var existedTeacher = Get(teacher.Id);
                    if (existedTeacher != null)
                    {
                        dbContext.Entry<Teacher>(existedTeacher).CurrentValues.SetValues(teacher);
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
