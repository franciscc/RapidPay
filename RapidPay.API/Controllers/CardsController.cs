using Microsoft.AspNetCore.Mvc;
using RapidPay.API.DTOs;
using RapidPay.API.Services.Interfaces;

namespace RapidPay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        public CardsController(ICardService cardService)
        {
            _cardService = cardService ?? throw new ArgumentNullException(nameof(cardService));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(CreateCardDTO dto)
        {
            var result = await _cardService.CreateCard(dto);

            return result == 0 ? BadRequest() : Created($"api/v1/Cards/{result}", result);
        }

        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetCardInfo(long cardNumber)
        {
            var result = await _cardService.GetCardInfo(cardNumber);

            return result is null ? NotFound() : Ok(result);
        }

        private readonly ICardService _cardService;
    }
}
