using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }
}
