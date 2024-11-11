using Bank.Connection;
using Bank.Interfaces;
using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly BankSberContext _context;
        public CardRepository(BankSberContext context)
        {
            _context = context;
        }

        public async Task<Card> CreateCardAsync(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<bool> DeleteCardAsync(int id)
        {
            var deletedEntry = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }

            _context.Cards.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Card>> GetAllAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card?> GetByIdAsync(int id)
        {
            return await _context.Cards.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Card?> UpdateCardAsync(int id, Card card)
        {
            var ExitingCard = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            if (ExitingCard == null)
            {
                return null;
            }

            ExitingCard.Id = id;
            ExitingCard.Number = card.Number;
            ExitingCard.DateStart = card.DateStart;
            ExitingCard.DateEnd = card.DateEnd;
            ExitingCard.Cvv = card.Cvv;
            ExitingCard.Balance = card.Balance;
            ExitingCard.CardTypeId = card.CardTypeId;
            ExitingCard.UserId = card.UserId;
            ExitingCard.CardType = card.CardType;
            ExitingCard.TransactionHistoryRecipientCards = card.TransactionHistoryRecipientCards;
            ExitingCard.TransactionHistorySendCards = card.TransactionHistorySendCards;
            ExitingCard.User = card.User;

            await _context.SaveChangesAsync();

            return ExitingCard;
        }
    }
}
