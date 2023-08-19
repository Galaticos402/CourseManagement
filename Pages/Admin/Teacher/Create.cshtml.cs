using CourseManagement.Repository.Majors;
using CourseManagement.Repository.Students;
using CourseManagement.Repository.StudentsRepo;
using CourseManagement.Repository.Teachers;
using CourseManagement.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CourseManagement.Pages.Admin.Teacher
{
    public class CreateModel : PageModel
    {
        public readonly IMajorRepository majorRepository;
        public readonly ITeacherRepository teacherRepository;

        public IEnumerable<Models.Major> Majors { get; set; } = new List<Models.Major>();
        public CreateModel(IMajorRepository majorRepository, ITeacherRepository teacherRepository)
        {
            this.majorRepository = majorRepository;
            this.teacherRepository = teacherRepository;
        }

        public async Task OnGet()
        {
            Majors = await majorRepository.GetAll();
        }
        public async Task<IActionResult> OnPost()
        {
            var teacherName = Request.Form["TeacherName"];
            var email = Request.Form["Email"];
            var phone = Request.Form["Phone"];
            var majorId = int.Parse(Request.Form["MajorId"]);
            // Generate default password
            var password = UtilityService.GenerateRandomPassword();



            Models.Teacher newTeacher = new Models.Teacher(teacherName, email, password, phone, majorId);
            HttpStatusCode statusCode = await teacherRepository.Create(newTeacher);

            if (statusCode.Equals(HttpStatusCode.Created))
            {
                //return RedirectToRoute("/Admin/Semester/Index");
            }


            return RedirectToPage("/Admin/Teacher/Index");
        }
    }
}
