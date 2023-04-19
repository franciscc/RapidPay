using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapidPay.API.DTOs;
using RapidPay.API.Services.Implementations;
using RapidPay.Data.Domains;
using RapidPay.Data.Repositories.Interfaces;

namespace RapidPay.Tests.Unit.Services
{
    [TestClass]
    public class CardServiceTests
    {
        private Mock<ICardRepository> _cardRepositoryMock;

        private CardService _target;

        [TestInitialize]
        public void BeforeEach()
        {
            _cardRepositoryMock = new Mock<ICardRepository>();

            _target = new CardService(_cardRepositoryMock.Object);
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenEmpty()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new CardService(null));
        }

        [TestMethod]
        public async Task CreateCard_ReturnsIdCreated_WhenSuccessful()
        {
            // expected
            var expected = 1;
            var cardNumber = 4517660178932553;
            var model = new CreateCardDTO()
            {
                CardNumber = cardNumber,
                SecurityCode = 481,
                ExpireDate = DateTime.UtcNow.AddDays(52),
                Owner = "Testsrr"
            };
            _cardRepositoryMock.Setup(x => x.CreateCard(It.IsAny<CardDomain>())).ReturnsAsync(1);

            // act
            var result = await _target.CreateCard(model);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task GetCardInfo_ReturnsCard_WhenSuccessful()
        {
            // expected
            var cardNumber = 4517660178932553;
            var model = new CreateCardDTO()
            {
                CardNumber = cardNumber,
                SecurityCode = 481,
                ExpireDate = DateTime.UtcNow.AddDays(52),
                Owner = "Testsrr"
            };
            _cardRepositoryMock.Setup(x => x.GetCardInfo(cardNumber)).ReturnsAsync(_cards.Where(x => x.CardNumber == cardNumber).FirstOrDefault());

            // act
            var result = await _target.GetCardInfo(cardNumber);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cardNumber, result.CardNumber);
        }


        private List<CardDomain> _cards = new List<CardDomain>()
        {
            new()
            {
                CardNumber = 4517660178932553
            },
            new()
            {
                CardNumber = 4517660178932363
            }
        };
    }
}
