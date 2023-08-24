using CourseManagement.Models;
using CourseManagement.Repository.Courses;
using CourseManagement.Repository.StudentsRepo;
using CourseManagement.Repository.Subjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;

namespace CourseManagement.Pages.Student.Register
{
    [Authorize(Roles = "Student")]
    public class IndexModel : PageModel
    {
        public readonly ISubjectRepository subjectRepository;
        public readonly IStudentRepository studentRepository;
        public readonly ICourseRepository courseRepository;
        public IEnumerable<Models.Subject> Subjects { get; set; } = new List<Models.Subject>();
        public IndexModel(ISubjectRepository subjectRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            this.subjectRepository = subjectRepository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }
        public async Task<IActionResult> OnGet(int page = 1)
        {
            int? studentId = HttpContext.Session.GetInt32("User");
            Models.Student student;
            if (studentId != null)
            {
                student = await studentRepository.Get(studentId);
                if(student == null)
                {
                    return RedirectToPage("/Login");
                }
            }
            else
            {
                return RedirectToPage("/Login");
            }
            Subjects = await subjectRepository.GetByMajorId(student.MajorId);
            var registeredSubject = await subjectRepository.GetRegisteredSubjectOfAStudent(studentId);
            Subjects = Subjects.Where(s => !registeredSubject.Contains(s.Id));
            return Page();
        }
        public async Task<IActionResult> OnPostRegister(int subjectId)
        {
            int? studentId = HttpContext.Session.GetInt32("User");
            List<Course> courses = await courseRepository.GetAllCoursesOfASubject(subjectId);
            if(courses.Count == 0)
            {
                TempData["Message"] = "There is no available course at the moment";
                return Redirect("/Student/Register");
            }
            var random = new Random();
            int index = random.Next(courses.Count);
            var courseId = courses[index].Id;
            await studentRepository.RegisterCourse(studentId, courseId);
            TempData["Message"] = "Register successfully";
            return Redirect("/Student/Register");
        }
    }
}
