using RapidPay.API.DTOs;
using RapidPay.API.Extensions;
using RapidPay.API.Services.Interfaces;

namespace RapidPay.API.Services.Implementations
{
    public class PaymentsService : IPaymentsService
    {
        public PaymentsService(ICardService cardService)
        {
            _cardService = cardService ?? throw new ArgumentNullException(nameof(cardService));
        }

        public async Task<BalanceDTO?> Pay(PayDTO pay)
        {
            pay.Validate();

            // get creditCard information
            var card = await _cardService.GetCardInfo(pay.CardNumber);
            if (card is null) return null;

            // apply fees
            var ufe = UniversalFeesExchange.Instance;
            var fee = ufe.GetNewFee();
            var updatedBalance = card.Balance - (pay.Amount + fee);

            // udpate card
            var result = await _cardService.UpdateCardBalance(card.CardNumber, updatedBalance);

            return result;
        }

        private readonly ICardService _cardService;
    }
}
