using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProducerService
    {
        Task<List<Producer>> GetAllProducersAsync();
        Task<Producer> GetProducerByIdAsync(int producerId);
        Task CreateProducerAsync(Producer producer);
        Task UpdateProducerAsync(Producer producer);
        Task DeleteProducerAsync(int producerId);
    }
}
