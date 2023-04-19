using RapidPay.API.DTOs;

namespace RapidPay.API.Services.Interfaces
{
    public interface IPaymentsService
    {
        Task<BalanceDTO?> Pay(PayDTO dto);
    }
}
