using CourseManagement.Models;
using CourseManagement.Repository.Majors;
using CourseManagement.Repository.Students;
using CourseManagement.Repository.StudentsRepo;
using CourseManagement.Repository.Subjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CourseManagement.Pages.Admin.Subject
{
    public class UpdateModel : PageModel
    {
        public readonly IMajorRepository majorRepository;
        public readonly ISubjectRepository subjectRepository;
        public IEnumerable<Major> Majors { get; set; } = new List<Major>();
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
            var id = int.Parse(Request.Form["Id"]);
            var subjectName = Request.Form["SubjectName"];
            var code = Request.Form["Code"];
            var majorId = int.Parse(Request.Form["MajorId"]);

            SelectedSubject = await subjectRepository.Get(id);

            if (SelectedSubject != null)
            {
                Models.Subject newSubject = new Models.Subject(subjectName, code,majorId);
                newSubject.Id = id;
                HttpStatusCode statusCode = await subjectRepository.Update(newSubject);
                if (statusCode.Equals(HttpStatusCode.Created))
                {
                    //return RedirectToRoute("/Admin/Semester/Index");
                }
            }




            return RedirectToPage("/Admin/Subject/Index");
        }
    }
}
