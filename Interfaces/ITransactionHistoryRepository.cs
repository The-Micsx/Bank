using Bank.Model;

namespace Bank.Interfaces
{
    public interface ITransactionHistoryRepository
    {
        Task<List<TransactionHistory>> GetAllAsync();
        Task<TransactionHistory?> GetByIdAsync(int id);
        Task<TransactionHistory> CreateTransactionHistoryAsync(TransactionHistory TransactionHistory);
        Task<bool> DeleteTransactionHistoryAsync(int id);
        Task<TransactionHistory?> UpdateTransactionHistoryAsync(int id, TransactionHistory TransactionHistory);
    }
}
