using AMAP_FARM.DTO;
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

        public async Task<Producer> GetProducerByUserIdAsync(int userId)
        {
            var producer = await _context.Producers
                .FirstOrDefaultAsync(p => p.Id == userId);

            return producer;
        }

        public async Task<Producer> CreateProducerAsync(ProducerCreateDto producerDto)
        {
            var user = new User
            {
                Username = producerDto.Username,
                Email = producerDto.Email,
                PasswordHash = producerDto.PasswordHash,
                FullName = producerDto.FullName,
                DateOfBirth = producerDto.DateOfBirth,
                RoleId = producerDto.RoleId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var producer = new Producer
            {
                UserId = user.Id,
                FarmName = producerDto.FarmName,
                Location = producerDto.Location,
                ContactNumber = producerDto.ContactNumber
            };

            _context.Producers.Add(producer);
            await _context.SaveChangesAsync();

            return producer;
        }

        public async Task<Producer> UpdateProducerAsync(int userId, ProducerUpdateDto producerUpdateDto)
        {
            var producer = await _context.Producers
                .FirstOrDefaultAsync(p => p.Id == userId);

            if (producer == null)
            {
                return null;
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            user.FullName = producerUpdateDto.FullName ?? user.FullName;

            producer.FarmName = producerUpdateDto.FarmName ?? producer.FarmName;
            producer.Location = producerUpdateDto.Location ?? producer.Location;
            producer.ContactNumber = producerUpdateDto.ContactNumber ?? producer.ContactNumber;

            _context.Users.Update(user);
            _context.Producers.Update(producer);

            await _context.SaveChangesAsync();

            return producer;
        }

        public async Task<bool> DeleteProducerAsync(int userId)
        {
            var producer = await _context.Producers
                .FirstOrDefaultAsync(p => p.Id == userId);

            if (producer == null)
            {
                return false;
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            _context.Producers.Remove(producer);
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
