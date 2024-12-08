using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class CoProducerService : ICoProducerService
    {
        private readonly AppDbContext _context;

        public CoProducerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CoProducer> GetCoProducerByUserIdAsync(int userId)
        {
            var coProducer = await _context.CoProducers
                .FirstOrDefaultAsync(cp => cp.UserId == userId);

            return coProducer;
        }

        public async Task<CoProducer> CreateCoProducerAsync(CoProducerCreateDto coProducerDto)
        {
            var user = new User
            {
                Username = coProducerDto.Username,
                Email = coProducerDto.Email,
                PasswordHash = coProducerDto.PasswordHash,
                FullName = coProducerDto.FullName,
                DateOfBirth = coProducerDto.DateOfBirth,
                RoleId = coProducerDto.RoleId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var coProducer = new CoProducer
            {
                UserId = user.Id,
                Location = coProducerDto.Location,
                ContactNumber = coProducerDto.ContactNumber
            };

            _context.CoProducers.Add(coProducer);
            await _context.SaveChangesAsync();

            return coProducer;
        }

        public async Task<CoProducer> UpdateCoProducerAsync(int userId, CoProducerUpdateDto coProducerUpdateDto)
        {
            var coProducer = await _context.CoProducers
                .FirstOrDefaultAsync(cp => cp.UserId == userId);

            if (coProducer == null)
            {
                return null;
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            user.FullName = coProducerUpdateDto.FullName ?? user.FullName;

            coProducer.Location = coProducerUpdateDto.Location ?? coProducer.Location;
            coProducer.ContactNumber = coProducerUpdateDto.ContactNumber ?? coProducer.ContactNumber;

            _context.Users.Update(user);
            _context.CoProducers.Update(coProducer);

            await _context.SaveChangesAsync();

            return coProducer;
        }

        public async Task<bool> DeleteCoProducerAsync(int userId)
        {
            var coProducer = await _context.CoProducers
                .FirstOrDefaultAsync(cp => cp.UserId == userId);

            if (coProducer == null)
            {
                return false;
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            _context.CoProducers.Remove(coProducer);
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
