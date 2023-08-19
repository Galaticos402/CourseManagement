using CourseManagement.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                    var teacher = await Get(teacherId);
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

        public async Task<Teacher?> Get(int teacherId)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Teachers.FindAsync(teacherId);
            }
        }

        public Teacher? GetByEmailAndPassword(string email, string password)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return dbContext.Teachers.Where(teacher => teacher.Email.Equals(email) && teacher.Pwd.Equals(password)).FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Teacher>> GetByMajorId(int majorId)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Teachers.Where(teacher => teacher.MajorId == majorId).ToListAsync();
            }
        }

        public async Task<IEnumerable<Teacher>> GetByPageNumber(int page)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Teachers.Skip(itemPerPage * (page - 1)).Include(t => t.Major).Take(itemPerPage).ToListAsync();
            }
        }
        public async Task<HttpStatusCode> Update(Teacher teacher)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    var existedTeacher = await Get(teacher.Id);
                    if (existedTeacher != null)
                    {
                        dbContext.Entry<Teacher>(existedTeacher).CurrentValues.SetValues(teacher);
                        dbContext.Entry(existedTeacher).State = EntityState.Modified;
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
