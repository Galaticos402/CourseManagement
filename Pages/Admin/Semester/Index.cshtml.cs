using CourseManagement.Models;
using CourseManagement.Repository.Semesters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CourseManagement.Pages.Admin.Semester
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        public readonly ISemesterRepository semesterRepository;
        public IEnumerable<Models.Semester> Semesters { get; set; } = new List<Models.Semester>();
        public IndexModel(ISemesterRepository semesterRepository) {
            this.semesterRepository = semesterRepository;
        }
        public async Task OnGet(int page = 1)
        {
            Semesters = await semesterRepository.GetSemestersByPageNumber(page);
        }
    }
}
