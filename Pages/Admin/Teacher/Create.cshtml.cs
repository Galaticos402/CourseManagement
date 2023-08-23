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
        [BindProperty]
        public Models.Teacher Teacher { get; set; }

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
            // Generate default password
            var password = UtilityService.GenerateRandomPassword();



            this.Teacher.Pwd = password;
            HttpStatusCode statusCode = await teacherRepository.Create(this.Teacher);

            if (statusCode.Equals(HttpStatusCode.Created))
            {
                return RedirectToPage("/Admin/Teacher/Index");
            }


            return RedirectToPage("/Error");
        }
    }
}
