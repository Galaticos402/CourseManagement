using CourseManagement.Models;

namespace CourseManagement.Repository.Admins
{
    public class AdminRepository : IAdminRepository
    {
        public Admin? GetByEmailAndPassword(string email, string password)
        {
            using (var dbContext = new CourseManagementContext())
            {
                return dbContext.Admins.Where(admin => admin.Email.Equals(email) && admin.Pwd.Equals(password)).FirstOrDefault();
            }
        }
    }
}
