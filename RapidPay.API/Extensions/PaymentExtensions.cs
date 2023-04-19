using RapidPay.API.DTOs;
using System.Diagnostics.CodeAnalysis;

namespace RapidPay.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class PaymentExtensions
    {
        public static void Validate(this PayDTO model)
        {
            if (model is null) throw new ArgumentNullException("Wrong parameters:)");

            if (model.CardNumber <= 0) throw new BadHttpRequestException("CardNumber is required");
            if (model.CardNumber.ToString().Length != 16) throw new BadHttpRequestException("Wrong CardNumber length (16 digits needed");

            if (model.Amount <= 0) throw new BadHttpRequestException("Nothing to pay:)"); 
        }
    }
}
