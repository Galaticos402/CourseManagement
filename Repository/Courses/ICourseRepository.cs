using CourseManagement.Models;

namespace CourseManagement.Repository.Courses
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesByPageNumber(int page);
    }
}
