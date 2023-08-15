using CourseManagement.Models;

namespace CourseManagement.Services
{
    public interface IAuthenticationService
    {
        bool AuthenticateUser(User user);
    }
}
