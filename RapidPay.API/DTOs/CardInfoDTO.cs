using System.Diagnostics.CodeAnalysis;

namespace RapidPay.API.DTOs
{
    [ExcludeFromCodeCoverage]
    public class CardInfoDTO
    {
        public long CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }
    }
}
