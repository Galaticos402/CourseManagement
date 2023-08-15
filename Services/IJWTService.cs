using CourseManagement.Models;

namespace CourseManagement.Services
{
    public interface IJWTService
    {
        Task<string> GenerateToken(User model, string role);
    }
}
