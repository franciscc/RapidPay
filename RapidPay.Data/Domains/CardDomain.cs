using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace RapidPay.Data.Domains
{
    [ExcludeFromCodeCoverage]
    public class CardDomain 
    {
        public int Id { get; set; }
        public long CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Owner { get; set; }
        public int SecurityCode { get; set; }
        public decimal Balance { get; set; }
    }
}
