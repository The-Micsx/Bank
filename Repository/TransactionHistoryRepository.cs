using Bank.Connection;
using Bank.Interfaces;
using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Repository
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly BankSberContext _context;
        public TransactionHistoryRepository(BankSberContext context)
        {
            _context = context;
        }

        public async Task<TransactionHistory> CreateTransactionHistoryAsync(TransactionHistory TransactionHistory)
        {
            await _context.TransactionHistories.AddAsync(TransactionHistory);
            await _context.SaveChangesAsync();
            return TransactionHistory;
        }

        public async Task<bool> DeleteTransactionHistoryAsync(int id)
        {
            var deletedEntry = await _context.TransactionHistories.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }

            _context.TransactionHistories.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TransactionHistory>> GetAllAsync()
        {
            return await _context.TransactionHistories.ToListAsync();
        }

        public async Task<TransactionHistory?> GetByIdAsync(int id)
        {
            return await _context.TransactionHistories.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TransactionHistory?> UpdateTransactionHistoryAsync(int id, TransactionHistory TransactionHistory)
        {
            var ExitingTransactionHistory = await _context.TransactionHistories.FirstOrDefaultAsync(c => c.Id == id);

            if (ExitingTransactionHistory == null)
            {
                return null;
            }

            ExitingTransactionHistory.Id = id;
            ExitingTransactionHistory.SendCardId = TransactionHistory.SendCardId;
            ExitingTransactionHistory.RecipientCardId = TransactionHistory.RecipientCardId;
            ExitingTransactionHistory.SunOfMoney = TransactionHistory.SunOfMoney;
            ExitingTransactionHistory.DatetimeDearture = TransactionHistory.DatetimeDearture;
            ExitingTransactionHistory.TransactionId = TransactionHistory.TransactionId;
            ExitingTransactionHistory.RecipientCard = TransactionHistory.RecipientCard;
            ExitingTransactionHistory.SendCard = TransactionHistory.SendCard;
            ExitingTransactionHistory.Transaction = TransactionHistory.Transaction;


            await _context.SaveChangesAsync();

            return ExitingTransactionHistory;
        }
    }
}
