using System.Diagnostics.CodeAnalysis;

namespace RapidPay.API.DTOs
{
    [ExcludeFromCodeCoverage]
    public class PayDTO
    {
        public long CardNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
