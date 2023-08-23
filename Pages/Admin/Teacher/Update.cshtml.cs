using CourseManagement.Repository.Majors;
using CourseManagement.Repository.Students;
using CourseManagement.Repository.StudentsRepo;
using CourseManagement.Repository.Teachers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CourseManagement.Pages.Admin.Teacher
{
    public class UpdateModel : PageModel
    {
        public readonly IMajorRepository majorRepository;
        public readonly ITeacherRepository teacherRepository;
        public IEnumerable<Models.Major> Majors { get; set; } = new List<Models.Major>();
        [BindProperty]
        public Models.Teacher? SelectedTeacher { get; set; }
        public UpdateModel(IMajorRepository majorRepository, ITeacherRepository teacherRepository)
        {
            this.majorRepository = majorRepository;
            this.teacherRepository = teacherRepository;
        }
        public async Task OnGet(int id)
        {
            Majors = await majorRepository.GetAll();
            SelectedTeacher = await teacherRepository.Get(id);
        }
        public async Task<IActionResult> OnPost()
        {

            if (SelectedTeacher != null)
            {
                HttpStatusCode statusCode = await teacherRepository.Update(SelectedTeacher);
                if (statusCode.Equals(HttpStatusCode.Created))
                {
                    //return RedirectToRoute("/Admin/Semester/Index");
                }
            }




            return RedirectToPage("/Admin/Teacher/Index");
        }
    }
}
