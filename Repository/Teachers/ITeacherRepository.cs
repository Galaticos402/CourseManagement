using CourseManagement.Models;
using System.Net;

namespace CourseManagement.Repository.Teachers
{
    public interface ITeacherRepository
    {
        Task<Teacher?> Get(int teacherId);
        Teacher? GetByEmailAndPassword(string email, string password);
        Task<IEnumerable<Teacher>> GetByPageNumber(int page);
        Task<IEnumerable<Teacher>> GetByMajorId(int majorId);
        Task<HttpStatusCode> Create(Teacher teacher);
        Task<HttpStatusCode> Update(Teacher teacher);
        Task<HttpStatusCode> Delete(int teacherId);
    }
}
