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
            var studentName = Request.Form["StudentName"];
            var email = Request.Form["Email"];
            var phone = Request.Form["Phone"];
            var majorId = int.Parse(Request.Form["MajorId"]);
            // Generate default password
            var password = UtilityService.GenerateRandomPassword();
            


            Models.Student newStudent = new Models.Student(studentName, email, password, phone, majorId);
            HttpStatusCode statusCode = await studentRepository.Create(newStudent);

            if (statusCode.Equals(HttpStatusCode.Created))
            {
                //return RedirectToRoute("/Admin/Semester/Index");
            }


            return RedirectToPage("/Admin/Student/Index");
        }
    }
}
