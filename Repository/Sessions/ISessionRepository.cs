using CourseManagement.Models;
using System.Net;

namespace CourseManagement.Repository.Sessions
{
    public interface ISessionRepository
    {
        Task<HttpStatusCode> CreateSessionsOfCouse(List<Session> sessions);
        Task<bool> SessionHasExistedByRoomSlotDate(int roomId, int slotId, DateTime? date);
    }
}
