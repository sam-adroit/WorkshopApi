using WorkshopApi.Models;

namespace WorkshopApi.Interfaces
{
    public interface IRegistrationService
    {
        Task<Registration> Register(Registration registration);
    }
}
