using CourseManagement.DTOs;
using CourseManagement.Models;
using CourseManagement.Repository.StudentsRepo;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CourseManagement.Repository.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly int itemPerPage = 10;
        public async Task<HttpStatusCode> Create(Student student)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    dbContext.Students.Add(student);
                    await dbContext.SaveChangesAsync();
                    return HttpStatusCode.Created;
                }catch (Exception ex) 
                { 
                    return HttpStatusCode.BadRequest;
                }

            }
        }

        public async Task<HttpStatusCode> Delete(int studentId)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    var student = await Get(studentId);
                    if(student != null)
                    {
                        dbContext.Students.Remove(student);
                        await dbContext.SaveChangesAsync();
                        return HttpStatusCode.OK;
                    }
                    else
                    {
                        return HttpStatusCode.BadRequest;
                    }
                }catch (Exception ex)
                {
                    return HttpStatusCode.BadGateway;
                }
            }
        }

        public async Task<Student?> Get(int studentId)
        {
            using(var dbContext = new CourseManagementContext())
            {
                return await dbContext.Students.FindAsync(studentId);
            }
        }

        public Student? GetByEmailAndPassword(string email, string password)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return dbContext.Students.Where(std => std.Email.Equals(email) && std.Pwd.Equals(password)).FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Student>> GetByPageNumber(int page)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return await dbContext.Students.Skip(itemPerPage * (page - 1)).Take(itemPerPage).Include(std => std.Major).ToListAsync();
            }
        }

        public async Task<HttpStatusCode> Update(Student student)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    var existedStudent = await Get(student.Id);
                    if (existedStudent != null)
                    {
                        dbContext.Entry<Student>(existedStudent).CurrentValues.SetValues(student);
                        dbContext.Entry(existedStudent).State = EntityState.Modified;
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
