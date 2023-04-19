using RapidPay.Data.Domains;

namespace RapidPay.Data.Repositories.Interfaces
{
    public interface ICardRepository
    {
        Task<int> CreateCard(CardDomain card);
        Task<CardDomain> UpdateCardBalance(long cardNumber, decimal newBalance);
        Task<CardDomain?> GetCardInfo(long cardNumber);
    }
}
