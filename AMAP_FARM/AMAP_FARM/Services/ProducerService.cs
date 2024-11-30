using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class ProducerService : IProducerService
    {
        private readonly AppDbContext _context;

        public ProducerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producer>> GetAllProducersAsync()
        {
            return await _context.Producers.ToListAsync();
        }

        public async Task<Producer> GetProducerByIdAsync(int producerId)
        {
            return await _context.Producers.FindAsync(producerId);
        }

        public async Task CreateProducerAsync(Producer producer)
        {
            _context.Producers.Add(producer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducerAsync(Producer producer)
        {
            _context.Producers.Update(producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProducerAsync(int producerId)
        {
            var producer = await _context.Producers.FindAsync(producerId);
            if (producer != null)
            {
                _context.Producers.Remove(producer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
