using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapidPay.API.Controllers;
using RapidPay.API.DTOs;
using RapidPay.API.Services.Implementations;
using RapidPay.API.Services.Interfaces;

namespace RapidPay.Tests.Unit.Controllers
{
    [TestClass]
    public class PaymentsControllerTests
    {
        private Mock<IPaymentsService> _paymentsServiceMock;

        private PaymentsController _target;
        
        [TestInitialize]
        public void BeforeEach()
        {
            _paymentsServiceMock = new Mock<IPaymentsService>();
            _target = new PaymentsController(_paymentsServiceMock.Object);
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenEmpty()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new PaymentsController(null));
        }

        [TestMethod]
        public async Task Pay_ReturnsBalance200k_WhenSuccessful()
        {
            // arrange
            var expected = new BalanceDTO()
            {
                Balance = (decimal)-124.294,
                CardNumber = 4517660178932553
            };
            var payDto = new PayDTO()
            {
                Amount = 1000,
                CardNumber = 4517660178932553
            };
            _paymentsServiceMock.Setup(x => x.Pay(payDto)).ReturnsAsync(expected);

            // act
            var result = await _target.Pay(payDto);

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Pay_Returns404NotFound_WhenCardNotFound()
        {
            // arrange
            var expected = new BalanceDTO()
            {
                Balance = (decimal)-124.294,
                CardNumber = 4517660178932553
            };
            var payDto = new PayDTO()
            {
                Amount = 1000,
                CardNumber = 4517660178932553
            };
            _paymentsServiceMock.Setup(x => x.Pay(payDto)).ReturnsAsync((BalanceDTO)null);

            // act
            var result = await _target.Pay(payDto);

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

    }
}
