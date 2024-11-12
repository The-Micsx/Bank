using Bank.Model;

namespace Bank.Interfaces
{
    public interface ITransactionTypeRepository
    {
        Task<List<TransactionType>> GetAllAsync();
        Task<TransactionType?> GetByIdAsync(int id);
        Task<TransactionType> CreateTransactionTypeAsync(TransactionType TransactionType);
        Task<bool> DeleteTransactionTypeAsync(int id);
        Task<TransactionType?> UpdateTransactionTypeAsync(int id, TransactionType TransactionType);
    }
}
