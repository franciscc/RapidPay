using RapidPay.API.Services.Implementations;
using RapidPay.API.Services.Interfaces;
using RapidPay.Data.Repositories.Implementations;
using RapidPay.Data.Repositories.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace RapidPay.API.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class Registration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IPaymentsService, PaymentsService>();

            return services;
        }
    }
}
