using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IFractionationService
    {
        Task<List<Fractionation>> GetAllFractionationsAsync();
        Task<Fractionation> GetFractionationByIdAsync(int fractionationId);
        Task CreateFractionationAsync(Fractionation fractionation);
        Task UpdateFractionationAsync(Fractionation fractionation);
        Task DeleteFractionationAsync(int fractionationId);
    }
}
