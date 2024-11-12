using Bank.Model;

namespace Bank.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetAllAsync();
        Task<UserRole?> GetByIdAsync(int id);
        Task<UserRole> CreateUserRoleAsync(UserRole UserRole);
        Task<bool> DeleteUserRoleAsync(int id);
        Task<UserRole?> UpdateUserRoleAsync(int id, UserRole UserRole);
    }
}
