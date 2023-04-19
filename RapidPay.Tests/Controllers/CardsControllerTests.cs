﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapidPay.API.Controllers;
using RapidPay.API.DTOs;
using RapidPay.API.Services.Interfaces;

namespace RapidPay.Tests.Controllers
{
    [TestClass]
    public class CardsControllerTests
    {
        private Mock<ICardService> _cardServiceMock;
        private CardsController _target;

        [TestInitialize]
        public void BeforeEach()
        {
            _cardServiceMock = new Mock<ICardService>();

            _target = new CardsController(_cardServiceMock.Object);
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenEmpty()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new CardsController(null));
        }

        [TestMethod]
        public async Task GetCardInfo_ReturnCardInfoAnd200k_WhenSuccessful()
        {
            // arrange
            var cardNumber = 4517660178932553;
            _cardServiceMock.Setup(x => x.GetCardInfo(cardNumber)).ReturnsAsync(_cards.Where(x => x.CardNumber == cardNumber).FirstOrDefault());

            // act
            var result = await _target.GetCardInfo(cardNumber);

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsTrue(_cards.Any(x => x.CardNumber == cardNumber));
        }

        [TestMethod]
        public async Task GetCardInfo_Returns404NotFound_WhenNotFound()
        {
            // arrange
            var cardNumber = 4517660178934933;
            _cardServiceMock.Setup(x => x.GetCardInfo(cardNumber)).ReturnsAsync(_cards.Where(x => x.CardNumber == cardNumber).FirstOrDefault());

            // act
            var result = await _target.GetCardInfo(cardNumber);

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
            Assert.IsFalse(_cards.Any(x => x.CardNumber == cardNumber));
        }

        private List<CardInfoDTO> _cards = new List<CardInfoDTO>()
        {
            new()
            {
                CardNumber = 4517660178932553
            },
            new()
            {
                CardNumber = 4517660178932248
            }
        };
    }
}
