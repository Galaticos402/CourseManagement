using CourseManagement.Models;
using CourseManagement.Repository.Courses;
using CourseManagement.Repository.Rooms;
using CourseManagement.Repository.Semesters;
using CourseManagement.Repository.Sessions;
using CourseManagement.Repository.Slots;
using CourseManagement.Repository.Subjects;
using CourseManagement.Repository.Teachers;
using CourseManagement.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Net;

namespace CourseManagement.Pages.Admin.Course
{
    public class CreateModel : PageModel
    {
        public IEnumerable<Models.Teacher> Teachers = new List<Models.Teacher>();
        public IEnumerable<Models.Semester> Semesters = new List<Models.Semester>();
        public IEnumerable<Slot> Slots = new List<Slot>();
        public IEnumerable<Room> Rooms = new List<Room>();
        public int SubjectId { get; set; }
        [BindProperty]
        public string CourseName { get; set; }
        [BindProperty]
        public int TeacherId { get; set; }
        [BindProperty]
        public int SemesterId { get; set; }
        [BindProperty]
        public List<string> selectedDaysInWeek { get; set; }
        [BindProperty]
        public List<string> selectedSlots { get; set; }

        public readonly ISubjectRepository subjectRepository;
        public readonly ITeacherRepository teacherRepository;
        public readonly ISemesterRepository semesterRepository;
        public readonly ISlotRepository slotRepository;
        public readonly IRoomRepository roomRepository;
        public readonly ICourseRepository courseRepository;
        public readonly ISessionRepository sessionRepository;
        public CreateModel(ISubjectRepository subjectRepository, ITeacherRepository teacherRepository, ISemesterRepository semesterRepository, ISlotRepository slotRepository, IRoomRepository roomRepository, ICourseRepository courseRepository, ISessionRepository sessionRepository)
        {
            
            this.subjectRepository = subjectRepository;
            this.teacherRepository = teacherRepository;
            this.semesterRepository = semesterRepository;
            this.slotRepository = slotRepository;
            this.roomRepository = roomRepository;
            this.courseRepository = courseRepository;
            this.sessionRepository = sessionRepository;
        }

        public async Task OnGet(int subjectId)
        {
            var subject = await subjectRepository.Get(subjectId);
            SubjectId = subjectId;
            Slots = await slotRepository.GetAll();
            
            if(subject != null)
            {
                int majorId = (int)(subject.MajorId != null ? subject.MajorId : -1);
                if(majorId != -1)
                {
                    Teachers = await teacherRepository.GetByMajorId(majorId);
                    Semesters = await semesterRepository.GetAll();
                    Rooms = await roomRepository.GetAll();
                }
                
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            List<Session> generatedSession = new List<Session>();
            var subjectId = int.Parse(Request.Form["SubjectId"]);
            var courseName = Request.Form["courseName"];
            var teacherId = int.Parse(Request.Form["teacherId"]);
            var semesterId = int.Parse(Request.Form["semesterId"]);
            List<string> selectedDaysInWeek = Request.Form["selectedDaysInWeek"].ToList();
            List<string> selectedSlots = Request.Form["selectedSlots"].ToList();
            var roomId = int.Parse(Request.Form["roomId"]);

            Models.Course newCourse = new Models.Course(courseName, teacherId, semesterId, subjectId);
            int courseId = await courseRepository.Create(newCourse);

            if(courseId != -1)
            {
                Models.Semester existingSemester = await semesterRepository.GetById(semesterId);

                foreach (var dayInWeek in selectedDaysInWeek)
                {
                    List<DateTime> sessionDates = UtilityService.GetDatesBetweenTwoDates(existingSemester.StartDate, existingSemester.EndDate, int.Parse(dayInWeek));
                    foreach (var sessionDate in sessionDates)
                    {
                        foreach (var slotId in selectedSlots)
                        {
                            Session newSession = new Session(courseId, teacherId,  roomId, int.Parse(slotId), sessionDate);
                            generatedSession.Add(newSession);
                        }
                    }

                }
                HttpStatusCode sessionStatusCode = await sessionRepository.CreateSessionsOfCouse(generatedSession);
                if(sessionStatusCode != HttpStatusCode.OK)
                {
                    // Do something here
                }
            }
            else
            {
                // Do something here
            }

            

            return RedirectToPage("/Admin/Course/Index?subjectId="+subjectId);
        }
    }
}
