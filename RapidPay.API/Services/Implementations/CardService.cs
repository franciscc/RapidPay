using RapidPay.API.DTOs;
using RapidPay.API.Extensions;
using RapidPay.API.Services.Interfaces;
using RapidPay.Data.Repositories.Interfaces;

namespace RapidPay.API.Services.Implementations
{
    public class CardService : ICardService
    {
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        }

        public async Task<int> CreateCard(CreateCardDTO card)
        {
            card.Validate();

            var cardDomain = card.ToDomain();

            var result = await _cardRepository.CreateCard(cardDomain);

            return result;
        }

        public async Task<CardInfoDTO?> GetCardInfo(long cardNumber)
        {
            cardNumber.ValidateCardNumber();

            var cardDomain = await _cardRepository.GetCardInfo(cardNumber);

            if (cardDomain is null) return null;

            var result = cardDomain.ToModelInfo();

            return result;
        }

        public async Task<BalanceDTO> UpdateCardBalance(long cardNumber, decimal balance)
        {
            var card = await _cardRepository.UpdateCardBalance(cardNumber, balance);

            var result = card.ToBalanceDTO();
           
            return result;
        }

        private readonly ICardRepository _cardRepository;
    }
}
