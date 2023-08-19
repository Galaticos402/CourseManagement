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
            var id = int.Parse(Request.Form["Id"]);
            var teacherName = Request.Form["TeacherName"];
            var email = Request.Form["Email"];
            var phone = Request.Form["Phone"];
            var majorId = int.Parse(Request.Form["MajorId"]);

            SelectedTeacher = await teacherRepository.Get(id);

            if (SelectedTeacher != null)
            {
                Models.Teacher newTeacher = new Models.Teacher(teacherName, email, SelectedTeacher.Pwd, phone, majorId);
                newTeacher.Id = id;
                HttpStatusCode statusCode = await teacherRepository.Update(newTeacher);
                if (statusCode.Equals(HttpStatusCode.Created))
                {
                    //return RedirectToRoute("/Admin/Semester/Index");
                }
            }




            return RedirectToPage("/Admin/Teacher/Index");
        }
    }
}
