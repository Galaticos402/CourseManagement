using CourseManagement.Repository.Students;
using CourseManagement.Repository.StudentsRepo;
using CourseManagement.Repository.Subjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CourseManagement.Pages.Student.Curriculum
{
    [Authorize(Roles = "Student")]
    public class IndexModel : PageModel
    {
        public readonly ISubjectRepository subjectRepository;
        public readonly IStudentRepository studentRepository;
        public IEnumerable<Models.Subject> Subjects { get; set; } = new List<Models.Subject>();
        public IndexModel(ISubjectRepository subjectRepository, IStudentRepository studentRepository)
        {
            this.subjectRepository = subjectRepository;
            this.studentRepository = studentRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            int? studentId = HttpContext.Session.GetInt32("User");
            Models.Student student;
            if (studentId != null)
            {
                student = await studentRepository.Get(studentId);
                if (student == null)
                {
                    return RedirectToPage("/Login");
                }
            }
            else
            {
                return RedirectToPage("/Login");
            }
            Subjects = await subjectRepository.GetByMajorId(student.MajorId);
            return Page();
        }
    }
}
