using CourseManagement.Repository.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagement.Pages.Admin.Course
{
    public class IndexModel : PageModel
    {
        public readonly ICourseRepository courseRepository;
        public IEnumerable<Models.Course> Courses { get; set; } = new List<Models.Course>();
        public int subjectId;
        public IndexModel(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public async Task<IActionResult> OnGet(int page = 1, int subjectId = -1)
        {
            this.subjectId = subjectId;
            if(subjectId == -1)
            {
                return Redirect("/Admin/Course");
            }
            Courses = await courseRepository.GetCourseByPageNumberAndSubjectId(page, subjectId);
            return Page();
        }
    }
}
