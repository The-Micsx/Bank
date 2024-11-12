using Bank.Model;

namespace Bank.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateUserAsync(User User);
        Task<bool> DeleteUserAsync(int id);
        Task<User?> UpdateUserAsync(int id, User User);
    }
}
