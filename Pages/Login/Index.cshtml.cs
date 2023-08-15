using CourseManagement.Models;
using CourseManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagement.Pages.Login
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public readonly IJWTService jwtService;

        public string StudentRole = "Student";
        public string TeacherRole = "Teacher";

        public IndexModel(IJWTService jwtService)
        {
            this.jwtService = jwtService;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() {
            var email = Request.Form["email"];
            var password = Request.Form["password"];
            var role = Request.Form["role"];

         

            //var token = await jwtService.GenerateToken(std, "Student");
            //HttpContext.Session.SetString("Token", token);

            return RedirectToPage("/Home/Index");
            

        }
    }
}
