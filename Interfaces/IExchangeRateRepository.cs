using Bank.Model;

namespace Bank.Interfaces
{
    public interface IExchangeRateRepository
    {
        Task<List<ExchangeRate>> GetAllAsync();
        Task<ExchangeRate?> GetByIdAsync(int id);
        Task<ExchangeRate> CreateExchangeRateAsync(ExchangeRate ExchangeRate);
        Task<bool> DeleteExchangeRateAsync(int id);
        Task<ExchangeRate?> UpdateExchangeRateAsync(int id, ExchangeRate ExchangeRate);
    }
}
