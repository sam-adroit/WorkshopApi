using WorkshopApi.Models;

namespace WorkshopApi.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<Registration> AddRegistrationAsync(Registration registration);
        Task<List<Workshop>> GetStudentWorkshopsAsync(int studentId);
        Task<bool> IsRegisteredAsync(int workshopId, int studentId);
    }
}
