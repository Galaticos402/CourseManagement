using CourseManagement.Models;
using CourseManagement.Repository.Majors;
using CourseManagement.Repository.Students;
using CourseManagement.Repository.Subjects;
using CourseManagement.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Net;

namespace CourseManagement.Pages.Admin.Subject
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        public readonly ISubjectRepository subjectRepository;
        public readonly IMajorRepository majorRepository;
        [BindProperty]
        public Models.Subject Subject { get; set; }
        public IEnumerable<Models.Major> Majors { get; set; } = new List<Models.Major>();
        public CreateModel(ISubjectRepository subjectRepository, IMajorRepository majorRepository)
        {
            this.majorRepository = majorRepository;
            this.subjectRepository = subjectRepository;
        }
        public async Task OnGet()
        {
            Majors = await majorRepository.GetAll();
        }
        public async Task<IActionResult> OnPost()
        {
           

            HttpStatusCode statusCode = await subjectRepository.Create(Subject);

            if (statusCode.Equals(HttpStatusCode.Created))
            {
                return RedirectToPage("/Admin/Subject/Index");
            }


            return RedirectToPage("/Error");
        }
    }
}
