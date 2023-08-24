using CourseManagement.Models;
using CourseManagement.Repository.Semesters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Globalization;
using System.Net;

namespace CourseManagement.Pages.Admin.Semester
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        public readonly ISemesterRepository semesterRepository;
        public CreateModel(ISemesterRepository semesterRepository) {
            this.semesterRepository = semesterRepository;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var semesterName = Request.Form["SemesterName"];
            var startDate = DateTime.ParseExact(Request.Form["StartDate"], "yyyy-MM-dd", null);
            var endDate = DateTime.ParseExact(Request.Form["EndDate"], "yyyy-MM-dd", null);


            Models.Semester newSemester = new Models.Semester(semesterName, startDate, endDate);
            HttpStatusCode statusCode = await semesterRepository.Create(newSemester);

            if(statusCode.Equals(HttpStatusCode.Created)) {
                //return RedirectToRoute("/Admin/Semester/Index");
            }


            return RedirectToPage("/Admin/Semester/Index");
        }
    }
}
