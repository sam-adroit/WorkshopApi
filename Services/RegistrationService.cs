using WorkshopApi.Interfaces;
using WorkshopApi.Models;

namespace WorkshopApi.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IRegistrationRepository _registrationRepository;
        public RegistrationService(IWorkshopRepository workshopRepository, IRegistrationRepository registrationRepository)
        {
            _workshopRepository = workshopRepository;
            _registrationRepository = registrationRepository;
        }
        public async Task<Registration> Register(Registration registration)
        {
            var workshop = await _workshopRepository.GetWorkshop(registration.WorkshopId);
            if (workshop is null)
                throw new KeyNotFoundException("Workshop not found.");
            if(workshop.RegistrationDeadline < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Registration deadline has passed.");
            }
            if (await _registrationRepository.IsRegisteredAsync(registration.WorkshopId, registration.StudentId))
                throw new InvalidOperationException("Student is already registered for this workshop.");
            var available = await _workshopRepository.GetAvailableWorkshops();
            if (!available.Any(w => w.Id == workshop.Id))
            {
                throw new InvalidOperationException("Workshop is full.");
            } 

            Registration registration1 = new Registration 
            {
                WorkshopId = registration.WorkshopId,
                StudentId = registration.StudentId,
                StudentName = registration.StudentName,
                StudentEmail = registration.StudentEmail,
                RegistrationDate = DateTime.UtcNow
            };
            return await _registrationRepository.AddRegistrationAsync(registration1);
        }
    }
}
