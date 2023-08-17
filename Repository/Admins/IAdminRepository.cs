using CourseManagement.Models;

namespace CourseManagement.Repository.Admins
{
    public interface IAdminRepository
    {
        Admin? GetByEmailAndPassword(string email, string password);
    }
}
