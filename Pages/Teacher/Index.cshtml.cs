using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CourseManagement.Pages.Teacher
{
    [Authorize(Roles = "Teacher")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
