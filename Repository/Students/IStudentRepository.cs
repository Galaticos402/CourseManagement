using CourseManagement.DTOs;
using CourseManagement.Models;
using System.Net;

namespace CourseManagement.Repository.StudentsRepo
{
    public interface IStudentRepository
    {
        Student? Get(int studentId);
        Task<HttpStatusCode> Create(Student student);
        Task<HttpStatusCode> Update(Student student);
        Task<HttpStatusCode> Delete(int studentId);
    }
}
