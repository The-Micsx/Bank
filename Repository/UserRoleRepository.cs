using Bank.Connection;
using Bank.Interfaces;
using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly BankSberContext _context;
        public UserRoleRepository(BankSberContext context)
        {
            _context = context;
        }

        public async Task<UserRole> CreateUserRoleAsync(UserRole UserRole)
        {
            await _context.UserRoles.AddAsync(UserRole);
            await _context.SaveChangesAsync();
            return UserRole;
        }

        public async Task<bool> DeleteUserRoleAsync(int id)
        {
            var deletedEntry = await _context.UserRoles.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }

            _context.UserRoles.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole?> GetByIdAsync(int id)
        {
            return await _context.UserRoles.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<UserRole?> UpdateUserRoleAsync(int id, UserRole UserRole)
        {
            var ExitingUserRole = await _context.UserRoles.FirstOrDefaultAsync(c => c.Id == id);

            if (ExitingUserRole == null)
            {
                return null;
            }

            ExitingUserRole.Id = id;
            ExitingUserRole.Name = UserRole.Name;
            ExitingUserRole.Users = UserRole.Users;

            await _context.SaveChangesAsync();

            return ExitingUserRole;
        }
    }
}
