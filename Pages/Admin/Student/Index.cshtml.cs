using CourseManagement.Repository.StudentsRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagement.Pages.Admin.Student
{
    public class IndexModel : PageModel
    {
        public readonly IStudentRepository studentRepository;
        public IEnumerable<Models.Student> Students { get; set; } = new List<Models.Student>();
        public IndexModel(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task OnGet(int page = 1)
        {
            Students = await studentRepository.GetByPageNumber(page);
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await studentRepository.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
