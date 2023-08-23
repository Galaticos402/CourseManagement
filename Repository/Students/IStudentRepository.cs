using CourseManagement.DTOs;
using CourseManagement.Models;
using System.Net;

namespace CourseManagement.Repository.StudentsRepo
{
    public interface IStudentRepository
    {
        Task<Student?> Get(int? studentId);
        Student? GetByEmailAndPassword(string email, string password);
        Task<IEnumerable<Student>> GetByPageNumber(int page);
        Task<HttpStatusCode> Create(Student student);
        Task<HttpStatusCode> Update(Student student);
        Task<HttpStatusCode> Delete(int studentId);
        Task<HttpStatusCode> RegisterCourse(int? studentId, int courseId);
    }
}
