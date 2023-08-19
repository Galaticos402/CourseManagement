using CourseManagement.Models;
using System.Net;

namespace CourseManagement.Repository.Subjects
{
    public interface ISubjectRepository
    {
        Task<Subject?> Get(int subjectId);
        Task<IEnumerable<Subject>> GetByPageNumber(int page);
        Task<HttpStatusCode> Create(Subject subject);
        Task<HttpStatusCode> Update(Subject student);
    }
}
