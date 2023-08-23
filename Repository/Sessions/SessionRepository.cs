using CourseManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> SessionHasExistedByRoomSlotDate(int roomId, int slotId, DateTime? date)
        {
            using (var dbContext = new CourseManagementContext())
            {
                try
                {
                    bool isEmpty = dbContext.Sessions.FirstOrDefault() == null;
                    return isEmpty || await dbContext.Sessions.Where(x => x.RoomId.Equals(roomId) && x.SlotId.Equals(slotId) && x.Date.Equals(date.Value.ToShortDateString())).FirstAsync() == null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }
    }
}
