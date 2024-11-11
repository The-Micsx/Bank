using Bank.Connection;
using Bank.Interfaces;
using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Repository
{
    public class HomeAdreRepository : IHomeAdreRepository
    {
        private readonly BankSberContext _context;
        public HomeAdreRepository(BankSberContext context)
        {
            _context = context;
        }

        public async Task<HomeAdre> CreateHomeAdreAsync(HomeAdre HomeAdre)
        {
            await _context.HomeAdres.AddAsync(HomeAdre);
            await _context.SaveChangesAsync();
            return HomeAdre;
        }

        public async Task<bool> DeleteHomeAdreAsync(int id)
        {
            var deletedEntry = await _context.HomeAdres.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }

            _context.HomeAdres.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<HomeAdre>> GetAllAsync()
        {
            return await _context.HomeAdres.ToListAsync();
        }

        public async Task<HomeAdre?> GetByIdAsync(int id)
        {
            return await _context.HomeAdres.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<HomeAdre?> UpdateHomeAdreAsync(int id, HomeAdre HomeAdre)
        {
            var ExitingHomeAdre = await _context.HomeAdres.FirstOrDefaultAsync(c => c.Id == id);

            if (ExitingHomeAdre == null)
            {
                return null;
            }

            ExitingHomeAdre.Id = id;
            ExitingHomeAdre.Country = HomeAdre.Country;
            ExitingHomeAdre.City = HomeAdre.City;
            ExitingHomeAdre.Adres = HomeAdre.Adres;
            ExitingHomeAdre.Home = HomeAdre.Home;
            ExitingHomeAdre.Apartment = HomeAdre.Apartment;
            ExitingHomeAdre.Users = HomeAdre.Users;

            await _context.SaveChangesAsync();

            return ExitingHomeAdre;
        }
    }
}
