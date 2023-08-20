using CourseManagement.Models;

namespace CourseManagement.Repository.Courses
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesByPageNumber(int page);
        Task<IEnumerable<Course>> GetCourseByPageNumberAndSubjectId(int page, int subjectId);
        Task<int> Create(Course course);
    }
}
