using CourseManagement.Repository.Students;
using CourseManagement.Repository.Teachers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CourseManagement.Pages.Admin.Teacher
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        public IEnumerable<Models.Teacher> Teachers = new List<Models.Teacher>();
        public readonly ITeacherRepository teacherRepository;
        public IndexModel(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public async Task OnGet(int page = 1)
        {
            Teachers = await teacherRepository.GetByPageNumber(page);
        }
        public async Task OnPostDelete(int id)
        {
            await teacherRepository.Delete(id);
        }
    }
}
