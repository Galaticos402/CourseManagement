using CourseManagement.Repository.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagement.Pages.Admin.Course
{
    public class IndexModel : PageModel
    {
        public readonly ICourseRepository courseRepository;
        public IEnumerable<Models.Course> Courses { get; set; } = new List<Models.Course>();
        public IndexModel(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public async Task OnGet(int page = 1)
        {
            Courses = await courseRepository.GetCoursesByPageNumber(page);
        }
    }
}
