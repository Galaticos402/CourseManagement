using CourseManagement.Models;
using CourseManagement.Repository.StudentsRepo;

namespace CourseManagement.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public readonly IStudentRepository studentRepository;
        public AuthenticationService(IStudentRepository studentRepository) {
            this.studentRepository = studentRepository;
        }
        public bool AuthenticateUser(User user, string role)
        {
            if(role == "Student") {
                return AuthenticateStudent(user);
            }else if(role == "Teacher")
            {
                return AuthenticateTeacher(user);
            } else if(role == "Admin")
            {
                return AuthenticateAdmin(user);
            }
            return false;
        }
        private bool AuthenticateStudent(User student)
        {
            var stdInDb = studentRepository.GetByEmailAndPassword(student.Email, student.Pwd);
            if(stdInDb != null)
            {
                return true;
            }
            return false;
        }
        private bool AuthenticateTeacher(User teacher)
        {
            return true;
        }
        private bool AuthenticateAdmin(User admin) { 
            return true;
        }
    }
}
