using CourseManagement.Models;

namespace CourseManagement.Repository.Majors
{
    public interface IMajorRepository
    {
        Task<IEnumerable<Major>> GetAll();
    }
}
