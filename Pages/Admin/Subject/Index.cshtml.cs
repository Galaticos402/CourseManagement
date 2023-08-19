using CourseManagement.Models;
using CourseManagement.Repository.Students;
using CourseManagement.Repository.Subjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagement.Pages.Admin.Subject
{
    public class IndexModel : PageModel
    {
        public readonly ISubjectRepository subjectRepository;
        public IEnumerable<Models.Subject> Subjects { get; set; } = new List<Models.Subject>();
        public IndexModel(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }
        public async Task OnGet(int page = 1)
        {
            Subjects = await subjectRepository.GetByPageNumber(page);
        }
    }
}
