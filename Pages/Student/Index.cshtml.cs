using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagement.Pages.Student
{
    //[Authorize(Roles = "Student")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
