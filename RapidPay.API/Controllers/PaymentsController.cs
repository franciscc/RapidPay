using Microsoft.AspNetCore.Mvc;
using RapidPay.API.DTOs;
using RapidPay.API.Services.Interfaces;

namespace RapidPay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService ?? throw new ArgumentNullException(nameof(paymentsService));
        }

        [HttpPost]
        public async Task<IActionResult> Pay(PayDTO pay)
        {
            var result = await _paymentsService.Pay(pay);

            return result != null ? Ok(result) : NotFound();
        }

        private readonly IPaymentsService _paymentsService;
    }
}
