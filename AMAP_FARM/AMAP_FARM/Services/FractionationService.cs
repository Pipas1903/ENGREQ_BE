using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class FractionationService : IFractionationService
    {
        private readonly AppDbContext _context;

        public FractionationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fractionation>> GetAllFractionationsAsync()
        {
            return await _context.Fractionations.ToListAsync();
        }

        public async Task<Fractionation> GetFractionationByIdAsync(int fractionationId)
        {
            return await _context.Fractionations
                .FirstOrDefaultAsync(f => f.Id == fractionationId);
        }

        public async Task CreateFractionationAsync(Fractionation fractionation)
        {
            await _context.Fractionations.AddAsync(fractionation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFractionationAsync(Fractionation fractionation)
        {
            _context.Fractionations.Update(fractionation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFractionationAsync(int fractionationId)
        {
            var fractionation = await _context.Fractionations
                .FirstOrDefaultAsync(f => f.Id == fractionationId);

            if (fractionation != null)
            {
                _context.Fractionations.Remove(fractionation);
                await _context.SaveChangesAsync();
            }
        }
    }
}

