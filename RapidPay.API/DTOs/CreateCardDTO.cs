using System.Diagnostics.CodeAnalysis;

namespace RapidPay.API.DTOs
{
    [ExcludeFromCodeCoverage]
    public class CreateCardDTO
    {
        public long CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Owner { get; set; }
        public int SecurityCode { get; set; }
    }
}
