using Bank.Connection;
using Bank.Interfaces;
using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Repository
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly BankSberContext _context;
        public TransactionTypeRepository(BankSberContext context)
        {
            _context = context;
        }

        public async Task<TransactionType> CreateTransactionTypeAsync(TransactionType TransactionType)
        {
            await _context.TransactionTypes.AddAsync(TransactionType);
            await _context.SaveChangesAsync();
            return TransactionType;
        }

        public async Task<bool> DeleteTransactionTypeAsync(int id)
        {
            var deletedEntry = await _context.TransactionTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }

            _context.TransactionTypes.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TransactionType>> GetAllAsync()
        {
            return await _context.TransactionTypes.ToListAsync();
        }

        public async Task<TransactionType?> GetByIdAsync(int id)
        {
            return await _context.TransactionTypes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TransactionType?> UpdateTransactionTypeAsync(int id, TransactionType TransactionType)
        {
            var ExitingTransactionType = await _context.TransactionTypes.FirstOrDefaultAsync(c => c.Id == id);

            if (ExitingTransactionType == null)
            {
                return null;
            }

            ExitingTransactionType.Id = id;
            ExitingTransactionType.Name = TransactionType.Name;
            ExitingTransactionType.TransactionHistories = TransactionType.TransactionHistories;

            await _context.SaveChangesAsync();

            return ExitingTransactionType;
        }
    }
}
