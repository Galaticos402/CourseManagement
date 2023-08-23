using CourseManagement.Models;
using System.Net;

namespace CourseManagement.Repository.Subjects
{
    public interface ISubjectRepository
    {
        Task<Subject?> Get(int subjectId);
        Task<IEnumerable<Subject>> GetByPageNumber(int page);
        Task<IEnumerable<Subject>> GetByMajorId(int majorId);
        Task<HttpStatusCode> Create(Subject subject);
        Task<HttpStatusCode> Update(Subject student);
        Task<List<int?>> GetRegisteredSubjectOfAStudent(int? studentId);
    }
}
