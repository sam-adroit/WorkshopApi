using WorkshopApi.Data;
using WorkshopApi.Interfaces;
using WorkshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkshopApi.Repositories
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private readonly AppDbContext _context;
        public WorkshopRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Workshop>> GetWorkshops() =>
            _context.Workshops.AsNoTracking().OrderBy(w => w.Date).ToListAsync();

        public async Task<Workshop?> GetWorkshop(int id) => await _context.Workshops.FindAsync(id);

        public Task<List<Workshop>> GetAvailableWorkshops() =>
            _context.Workshops.AsNoTracking()
                .Where(w => w.Date > DateTime.UtcNow &&
                            w.RegistrationDeadline >= DateTime.UtcNow &&
                            w.Capacity > _context.Registrations.Count(r => r.WorkshopId == w.Id))
                .OrderBy(w => w.Date)
                .ToListAsync();

        public async Task<Workshop> AddWorkshop(Workshop workshop)
        {
            workshop.Date = workshop.Date.ToUniversalTime();
            workshop.RegistrationDeadline = workshop.RegistrationDeadline.ToUniversalTime();
            _context.Workshops.Add(workshop);
            await _context.SaveChangesAsync();
            return workshop;
        }

        public async Task<bool> UpdateWorkshop(Workshop workshop)
        {
            var existingWorkshop = await _context.Workshops.FindAsync(workshop.Id);
            if (existingWorkshop is null) return false;

            _context.Workshops.Update(workshop);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
