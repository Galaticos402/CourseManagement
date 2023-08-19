using CourseManagement.Repository.Majors;
using CourseManagement.Repository.Students;
using CourseManagement.Repository.Subjects;
using CourseManagement.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CourseManagement.Pages.Admin.Subject
{
    public class CreateModel : PageModel
    {
        public readonly ISubjectRepository subjectRepository;
        public readonly IMajorRepository majorRepository;
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
            var subjectName = Request.Form["SubjectName"];
            var code = Request.Form["Code"];
            var majorId = int.Parse(Request.Form["MajorId"]);



            Models.Subject newSubject = new Models.Subject(subjectName, code , majorId);
            HttpStatusCode statusCode = await subjectRepository.Create(newSubject);

            if (statusCode.Equals(HttpStatusCode.Created))
            {
                //return RedirectToRoute("/Admin/Semester/Index");
            }


            return RedirectToPage("/Admin/Subject/Index");
        }
    }
}
