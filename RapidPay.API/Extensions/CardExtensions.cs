using RapidPay.API.DTOs;
using RapidPay.Data.Domains;
using System.Diagnostics.CodeAnalysis;

namespace RapidPay.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class CardExtensions
    {
        public static CardDomain ToDomain(this CreateCardDTO model)
        {
            return new()
            { 
                CardNumber = model.CardNumber,
                SecurityCode = model.SecurityCode,  
                ExpireDate = model.ExpireDate,
                Owner = model.Owner,
                Balance = 0,
            };
        }

        public static CardInfoDTO ToModelInfo(this CardDomain domain)
        {
            return new()
            {
                CardNumber = domain.CardNumber,
                ExpireDate = domain.ExpireDate,
                Balance = domain.Balance,
                Owner = domain.Owner
            };
        }

        public static BalanceDTO ToBalanceDTO(this CardDomain domain)
        {
            return new()
            {
                Balance = domain.Balance,
                CardNumber = domain.CardNumber
            };
        }

        public static void Validate(this CreateCardDTO model)
        {
            if (model is null) throw new BadHttpRequestException("Wrong parameters");

            if (model.CardNumber <= 0) throw new BadHttpRequestException("CardNumber is required");
            if (model.CardNumber.ToString().Length != 16) throw new BadHttpRequestException("Wrong CardNumber length (16 digits needed");

            if (model.ExpireDate <= DateTime.UtcNow) throw new BadHttpRequestException("ExpireDate is not valid");

            if (string.IsNullOrEmpty(model.Owner)) throw new BadHttpRequestException("Owner is required");

            if (model.SecurityCode < 100 || model.SecurityCode > 999) throw new BadHttpRequestException("Invalid SecurityCode (3 digits needed)");
        }

        public static void ValidateCardNumber(this long cardNumber)
        {
            if(cardNumber <= 0) throw new BadHttpRequestException("CardNumber is required");
            if(cardNumber.ToString().Length != 16) throw new BadHttpRequestException("Wrong CardNumber length (16 digits needed");
        }
    }
}
