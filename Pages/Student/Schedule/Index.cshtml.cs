using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CourseManagement.Pages.Home.Schedule
{
    [Authorize(Roles = "Student")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
