using CourseManagement.Repository.Majors;
using CourseManagement.Repository.StudentsRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CourseManagement.Pages.Admin.Student
{
    public class UpdateModel : PageModel
    {
        public readonly IMajorRepository majorRepository;
        public readonly IStudentRepository studentRepository;
        public IEnumerable<Models.Major> Majors { get; set; } = new List<Models.Major>();
        public Models.Student? SelectedStudent { get; set; }
        public UpdateModel(IMajorRepository majorRepository, IStudentRepository studentRepository)
        {
            this.majorRepository = majorRepository;
            this.studentRepository = studentRepository;
        }
        public async Task OnGet(int id)
        {
            Majors = await majorRepository.GetAll();
            SelectedStudent = await studentRepository.Get(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var id = int.Parse(Request.Form["Id"]);
            var studentName = Request.Form["StudentName"];
            var email = Request.Form["Email"];
            var phone = Request.Form["Phone"];
            var majorId = int.Parse(Request.Form["MajorId"]);

            SelectedStudent = await studentRepository.Get(id);

            if(SelectedStudent != null)
            {
                Models.Student newStudent = new Models.Student(studentName, email, SelectedStudent.Pwd, phone, majorId);
                newStudent.Id = id;
                HttpStatusCode statusCode = await studentRepository.Update(newStudent);
                if (statusCode.Equals(HttpStatusCode.Created))
                {
                    //return RedirectToRoute("/Admin/Semester/Index");
                }
            }

           


            return RedirectToPage("/Admin/Student/Index");
        }
    }
}
