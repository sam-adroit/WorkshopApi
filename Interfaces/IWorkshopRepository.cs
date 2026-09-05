using WorkshopApi.Models;

namespace WorkshopApi.Interfaces
{
    public interface IWorkshopRepository
    {
        Task<List<Workshop>> GetWorkshops();
        Task<Workshop?> GetWorkshop(int id);
        Task<List<Workshop>> GetAvailableWorkshops();
        Task<Workshop> AddWorkshop(Workshop workshop);
        Task<bool> UpdateWorkshop(Workshop workshop);
    }
}
