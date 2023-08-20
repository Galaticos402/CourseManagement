using CourseManagement.Models;
using System.Net;

namespace CourseManagement.Repository.Sessions
{
    public class SessionRepository : ISessionRepository
    {
        public async Task<HttpStatusCode> CreateSessionsOfCouse(List<Session> sessions)
        {
            using(var dbContext = new CourseManagementContext())
            {
                try
                {
                    dbContext.Sessions.AddRange(sessions);
                    await dbContext.SaveChangesAsync();
                    return HttpStatusCode.Created;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                
            }
        }
       
    }
}
