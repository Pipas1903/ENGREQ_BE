using AMAP_FARM.DTO;
using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IFractionationService
    {
        Task<IEnumerable<Fractionation>> GetAllFractionationsAsync();
        Task<Fractionation> GetFractionationByIdAsync(int id);
        Task<Fractionation> CreateFractionationAsync(FractionationCreateDto fractionationCreateDto);
        Task<bool> UpdateFractionationAsync(int id, Fractionation fractionation);
        Task<bool> DeleteFractionationAsync(int id);
    }
}
