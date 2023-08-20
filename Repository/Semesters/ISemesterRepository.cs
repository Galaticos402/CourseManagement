using CourseManagement.Models;
using System.Net;

namespace CourseManagement.Repository.Semesters
{
    public interface ISemesterRepository
    {
        Task<IEnumerable<Semester>> GetSemestersByPageNumber(int page);
        Task<IEnumerable<Semester>> GetAll();
        Task<Semester> GetById(int semesterId);
        Task<HttpStatusCode> Create(Semester semester);
    }
}
