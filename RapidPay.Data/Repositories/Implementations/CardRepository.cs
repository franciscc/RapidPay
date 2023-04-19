using Microsoft.EntityFrameworkCore;
using RapidPay.Data.Context;
using RapidPay.Data.Domains;
using RapidPay.Data.Repositories.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace RapidPay.Data.Repositories.Implementations
{
    [ExcludeFromCodeCoverage]
    public class CardRepository : ICardRepository
    {
        public CardRepository(RapidPayContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> CreateCard(CardDomain card)
        {
            var result = await _context.Cards.AddAsync(card);

            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<CardDomain?> GetCardInfo(long cardNumber)
        {
            var result = await _context.Cards.Where(x => x.CardNumber == cardNumber).FirstOrDefaultAsync();

            return result;
        }

        public async Task<CardDomain> UpdateCardBalance(long cardNumber, decimal newBalance)
        {
            var domain = await _context.Cards.Where(x => x.CardNumber == cardNumber).FirstOrDefaultAsync();

            domain!.Balance = newBalance;

            await _context.SaveChangesAsync();

            return domain;
        }

        private readonly RapidPayContext _context;
    }
}
