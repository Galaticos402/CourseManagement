using CourseManagement.Models;

namespace CourseManagement.Repository.Slots
{
    public interface ISlotRepository
    {
        Task<IEnumerable<Slot>> GetAll();
    }
}
