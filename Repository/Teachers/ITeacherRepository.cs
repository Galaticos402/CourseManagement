using CourseManagement.Models;
using System.Net;

namespace CourseManagement.Repository.Teachers
{
    public interface ITeacherRepository
    {
        Teacher? Get(int teacherId);
        Teacher? GetByEmailAndPassword(string email, string password);
        Task<HttpStatusCode> Create(Teacher teacher);
        Task<HttpStatusCode> Update(Teacher teacher);
        Task<HttpStatusCode> Delete(int teacherId);
    }
}
