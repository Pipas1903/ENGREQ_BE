using AMAP_FARM.DTO;
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

        public async Task<IEnumerable<Fractionation>> GetAllFractionationsAsync()
        {
            return await _context.Fractionations.ToListAsync();
        }

        public async Task<Fractionation> GetFractionationByIdAsync(int id)
        {
            return await _context.Fractionations.FindAsync(id);
        }

        public async Task<Fractionation> CreateFractionationAsync(FractionationCreateDto fractionationCreateDto)
        {
            var fractionation = new Fractionation
            {
                Name = fractionationCreateDto.Name
            };

            _context.Fractionations.Add(fractionation);
            await _context.SaveChangesAsync();

            return fractionation;
        }

        public async Task<bool> UpdateFractionationAsync(int id, Fractionation fractionation)
        {
            var existingFractionation = await _context.Fractionations.FindAsync(id);
            if (existingFractionation == null)
            {
                return false;
            }

            existingFractionation.Name = fractionation.Name;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFractionationAsync(int id)
        {
            var fractionation = await _context.Fractionations.FindAsync(id);
            if (fractionation == null)
            {
                return false;
            }

            _context.Fractionations.Remove(fractionation);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
