using System.Diagnostics.CodeAnalysis;

namespace RapidPay.API.DTOs
{
    [ExcludeFromCodeCoverage]
    public class BalanceDTO
    {
        public long CardNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
