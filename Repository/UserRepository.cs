using Bank.Connection;
using Bank.Interfaces;
using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BankSberContext _context;
        public UserRepository(BankSberContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User User)
        {
            await _context.Users.AddAsync(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var deletedEntry = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }

            _context.Users.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<User?> UpdateUserAsync(int id, User User)
        {
            var ExitingUser = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);

            if (ExitingUser == null)
            {
                return null;
            }

            ExitingUser.Id = id;
            ExitingUser.Name = User.Name;
            ExitingUser.Telephone = User.Telephone;
            ExitingUser.Email = User.Email;
            ExitingUser.Password = User.Password;
            ExitingUser.RoleId = User.RoleId;
            ExitingUser.HomeAdres = User.HomeAdres;
            ExitingUser.Image = User.Image;
            ExitingUser.Cards = User.Cards;
            ExitingUser.HomeAdresNavigation = User.HomeAdresNavigation;
            ExitingUser.Role = User.Role;

            await _context.SaveChangesAsync();

            return ExitingUser;
        }
    }
}
