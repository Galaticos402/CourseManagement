using CourseManagement.Models;
using CourseManagement.Repository.Majors;
using CourseManagement.Repository.Semesters;
using CourseManagement.Repository.StudentsRepo;
using CourseManagement.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Net;

namespace CourseManagement.Pages.Admin.Student
{
    public class CreateModel : PageModel
    {
        public readonly IMajorRepository majorRepository;
        public readonly IStudentRepository studentRepository;
        public Models.Student Student { get; set; }
        public IEnumerable<Models.Major> Majors { get; set; } = new List<Models.Major>();
        public CreateModel(IMajorRepository majorRepository, IStudentRepository studentRepository) { 
            this.majorRepository = majorRepository;
            this.studentRepository = studentRepository;
        }
        public async Task OnGet()
        {
            Majors = await majorRepository.GetAll();
        }

        public async Task<IActionResult> OnPost()
        {
           
            // Generate default password
            var password = UtilityService.GenerateRandomPassword();
            
            this.Student.Pwd = password;
            HttpStatusCode statusCode = await studentRepository.Create(this.Student);

            if (statusCode.Equals(HttpStatusCode.Created))
            {
                return RedirectToPage("/Admin/Student/Index");
            }


            return RedirectToPage("/Error");
        }
    }
}
