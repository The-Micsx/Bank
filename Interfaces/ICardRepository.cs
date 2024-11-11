using Bank.Model;

namespace Bank.Interfaces
{
    public interface ICardRepository
    {
        Task<List<Card>> GetAllAsync();
        Task<Card?> GetByIdAsync(int id);
        Task<Card> CreateCardAsync(Card card);
        Task<bool> DeleteCardAsync(int id);
        Task<Card?> UpdateCardAsync(int id, Card card);
    }
}
