using WorkshopApi.Data;
using WorkshopApi.Interfaces;
using WorkshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkshopApi.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _context;
        public RegistrationRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<Registration> AddRegistrationAsync(Registration registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        public Task<bool> IsRegisteredAsync(int workshopId, int studentId) =>
            _context.Registrations.AnyAsync(r => r.WorkshopId == workshopId && r.StudentId == studentId);

        public Task<List<Workshop>> GetStudentWorkshopsAsync(int studentId) =>
            (from registration in _context.Registrations
             join workshop in _context.Workshops on registration.WorkshopId equals workshop.Id
             where registration.StudentId == studentId
             orderby workshop.Date
             select workshop).AsNoTracking().ToListAsync();
    }
}
