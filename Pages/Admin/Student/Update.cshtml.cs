using CourseManagement.Repository.Majors;
using CourseManagement.Repository.StudentsRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CourseManagement.Pages.Admin.Student
{
    public class UpdateModel : PageModel
    {
        public readonly IMajorRepository majorRepository;
        public readonly IStudentRepository studentRepository;
        public IEnumerable<Models.Major> Majors { get; set; } = new List<Models.Major>();
        [BindProperty]
        public Models.Student? SelectedStudent { get; set; }
        public UpdateModel(IMajorRepository majorRepository, IStudentRepository studentRepository)
        {
            this.majorRepository = majorRepository;
            this.studentRepository = studentRepository;
        }
        public async Task OnGet(int id)
        {
            Majors = await majorRepository.GetAll();
            SelectedStudent = await studentRepository.Get(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(SelectedStudent != null)
            {
                HttpStatusCode statusCode = await studentRepository.Update(SelectedStudent);
                if (statusCode.Equals(HttpStatusCode.Created))
                {
                    return RedirectToPage("/Admin/Student/Index");
                }
            }

            return RedirectToPage("/Error");
        }
    }
}
