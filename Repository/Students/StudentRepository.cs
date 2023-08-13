using CourseManagement.DTOs;
using CourseManagement.Models;
using CourseManagement.Repository.StudentsRepo;
using System.Net;

namespace CourseManagement.Repository.Students
{
    public class StudentRepository : IStudentRepository
    {
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
                    var student = Get(studentId);
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

        public Student? Get(int studentId)
        {
            using(var dbContext = new CourseManagementContext())
            {
                return dbContext.Students.Find(studentId);
            }
        }

        public async Task<HttpStatusCode> Update(Student student)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    var existedStudent = Get(student.Id);
                    if (existedStudent != null)
                    {
                        dbContext.Entry<Student>(existedStudent).CurrentValues.SetValues(student);
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
