using CourseManagement.Models;
using CourseManagement.Repository.Majors;
using CourseManagement.Repository.Students;
using CourseManagement.Repository.StudentsRepo;
using CourseManagement.Repository.Subjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Net;

namespace CourseManagement.Pages.Admin.Subject
{
    [Authorize(Roles = "Admin")]
    public class UpdateModel : PageModel
    {
        public readonly IMajorRepository majorRepository;
        public readonly ISubjectRepository subjectRepository;
        public IEnumerable<Major> Majors { get; set; } = new List<Major>();
        [BindProperty]
        public Models.Subject SelectedSubject { get; set; }
        public UpdateModel(IMajorRepository majorRepository, ISubjectRepository subjectRepository)
        {
            this.majorRepository = majorRepository;
            this.subjectRepository = subjectRepository;
        }

        public async Task OnGet(int id)
        {
            Majors = await majorRepository.GetAll();
            SelectedSubject = await subjectRepository.Get(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (SelectedSubject != null)
            {
                HttpStatusCode statusCode = await subjectRepository.Update(SelectedSubject);
                if (statusCode.Equals(HttpStatusCode.OK))
                {
                    return RedirectToPage("/Admin/Subject/Index");
                }
            }




            return RedirectToPage("/Error");
        }
    }
}
