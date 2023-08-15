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
        public bool AuthenticateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
