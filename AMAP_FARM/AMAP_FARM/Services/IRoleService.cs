using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(int roleId);
        Task CreateRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int roleId);
    }
}
