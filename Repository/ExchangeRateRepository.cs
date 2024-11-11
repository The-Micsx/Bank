using Bank.Connection;
using Bank.Interfaces;
using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Repository
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly BankSberContext _context;
        public ExchangeRateRepository(BankSberContext context)
        {
            _context = context;
        }

        public async Task<ExchangeRate> CreateExchangeRateAsync(ExchangeRate ExchangeRate)
        {
            await _context.ExchangeRates.AddAsync(ExchangeRate);
            await _context.SaveChangesAsync();
            return ExchangeRate;
        }

        public async Task<bool> DeleteExchangeRateAsync(int id)
        {
            var deletedEntry = await _context.ExchangeRates.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }

            _context.ExchangeRates.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ExchangeRate>> GetAllAsync()
        {
            return await _context.ExchangeRates.ToListAsync();
        }

        public async Task<ExchangeRate?> GetByIdAsync(int id)
        {
            return await _context.ExchangeRates.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ExchangeRate?> UpdateExchangeRateAsync(int id, ExchangeRate ExchangeRate)
        {
            var ExitingExchangeRate = await _context.ExchangeRates.FirstOrDefaultAsync(c => c.Id == id);

            if (ExitingExchangeRate == null)
            {
                return null;
            }

            ExitingExchangeRate.Id = id;
            ExitingExchangeRate.Name = ExchangeRate.Name;
            ExitingExchangeRate.Price = ExchangeRate.Price;

            await _context.SaveChangesAsync();

            return ExitingExchangeRate;
        }
    }
}
