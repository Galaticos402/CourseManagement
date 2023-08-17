using CourseManagement.Models;
using CourseManagement.Repository.Admins;
using CourseManagement.Repository.StudentsRepo;
using CourseManagement.Repository.Teachers;
using CourseManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagement.Pages.Login
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public readonly IJWTService jwtService;
        public readonly IStudentRepository studentRepository;
        public readonly ITeacherRepository teacherRepository;
        public readonly IAdminRepository adminRepository;

        public string StudentRole = "Student";
        public string TeacherRole = "Teacher";
        public string AdminRole = "Admin";
        public IndexModel(IJWTService jwtService, IStudentRepository studentRepository, ITeacherRepository teacherRepository, IAdminRepository adminRepository)
        {
            this.jwtService = jwtService;
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
            this.adminRepository = adminRepository;
        }

        public void OnGet()
        {
            HttpContext.Session.Remove("Token");
        }
        public async Task<IActionResult> OnPost() {
            var email = Request.Form["email"];
            var password = Request.Form["password"];
            var role = Request.Form["role"];
            if (role.Equals("Student"))
            {
                var existedStudent = studentRepository.GetByEmailAndPassword(email, password);
                if(existedStudent != null)
                {
                    var token = await jwtService.GenerateToken(existedStudent, "Student");
                    HttpContext.Session.SetString("Token", token);
                    return RedirectToPage("/Student/Index");
                }
            }

            if (role.Equals("Teacher"))
            {
                var existedTeacher = teacherRepository.GetByEmailAndPassword(email, password);
                if(existedTeacher != null)
                {
                    var token = await jwtService.GenerateToken(existedTeacher, "Teacher");
                    HttpContext.Session.SetString("Token", token);
                    return RedirectToPage("/Teacher/Index");
                }
            }

            if (role.Equals("Admin"))
            {
                var existedAdmin = adminRepository.GetByEmailAndPassword(email, password);
                if (existedAdmin != null)
                {
                    var token = await jwtService.GenerateToken(existedAdmin, "Admin");
                    HttpContext.Session.SetString("Token", token);
                    return RedirectToPage("/Admin/Index");
                }
            }

            return RedirectToPage("/Login/Index");
            

        }
    }
}
