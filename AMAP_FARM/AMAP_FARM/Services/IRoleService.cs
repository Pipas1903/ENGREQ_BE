using AMAP_FARM.DTO;
using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(int id);
        Task<Role> CreateRoleAsync(RoleCreateDto roleCreateDto);
        Task<bool> UpdateRoleAsync(int id, Role role);
        Task<bool> DeleteRoleAsync(int id);
    }
}
