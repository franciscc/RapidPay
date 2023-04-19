using Microsoft.EntityFrameworkCore;
using RapidPay.Data.Domains;
using System.Diagnostics.CodeAnalysis;

namespace RapidPay.Data.Context
{
    [ExcludeFromCodeCoverage]
    public class RapidPayContext : DbContext
    {
        public RapidPayContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CardDomain> Cards { get; set; }
    }
}
