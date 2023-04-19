using RapidPay.API.DTOs;
using RapidPay.Data.Domains;

namespace RapidPay.API.Services.Interfaces
{
    public interface ICardService
    {
        Task<int> CreateCard(CreateCardDTO card);
        Task<CardInfoDTO?> GetCardInfo(long cardNumber);
        Task<BalanceDTO> UpdateCardBalance(long cardNumber, decimal newBalance);
    }
}
