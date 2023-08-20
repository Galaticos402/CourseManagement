using CourseManagement.Models;
using CourseManagement.Repository.Semesters;
using CourseManagement.Repository.Slots;
using CourseManagement.Repository.Subjects;
using CourseManagement.Repository.Teachers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagement.Pages.Admin.Course
{
    public class CreateModel : PageModel
    {
        public IEnumerable<Models.Teacher> Teachers = new List<Models.Teacher>();
        public IEnumerable<Models.Semester> Semesters = new List<Models.Semester>();
        public IEnumerable<Slot> Slots = new List<Slot>();
        public Models.Subject Subject = new Models.Subject();

        public readonly ISubjectRepository subjectRepository;
        public readonly ITeacherRepository teacherRepository;
        public readonly ISemesterRepository semesterRepository;
        public readonly ISlotRepository slotRepository;
        public CreateModel(ISubjectRepository subjectRepository, ITeacherRepository teacherRepository, ISemesterRepository semesterRepository, ISlotRepository slotRepository)
        {
            
            this.subjectRepository = subjectRepository;
            this.teacherRepository = teacherRepository;
            this.semesterRepository = semesterRepository;
            this.slotRepository = slotRepository;
        }

        public async Task OnGet(int subjectId)
        {
            var subject = await subjectRepository.Get(subjectId);
            Slots = await slotRepository.GetAll();
            Subject = subject;
            if(subject != null)
            {
                int majorId = (int)(subject.MajorId != null ? subject.MajorId : -1);
                if(majorId != -1)
                {
                    Teachers = await teacherRepository.GetByMajorId(majorId);
                    Semesters = await semesterRepository.GetAll();
                }
                
            }
        }
    }
}
