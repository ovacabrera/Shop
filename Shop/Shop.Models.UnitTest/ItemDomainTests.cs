using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.CrossCutting;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using System.Collections.Generic;

namespace Shop.Models.UnitTest
{
    [TestClass]
    public class ItemDomainTests
    {
        [TestMethod]
        public void ValidateItemIdParameter_ItemIdIsStringEmpty_ReturnsFalse()
        {
            #region Arrange
            var externalService = new Mock<IExternalService>();
            var loggerService = new Mock<ILoggerService>();

            ItemDomain model = new ItemDomain(externalService.Object, loggerService.Object);

            #endregion

            #region Act

            var validate = model.ValidateItemIdParameter(string.Empty);

            #endregion

            #region Assert

            Assert.IsFalse(validate);

            #endregion

        }

        [TestMethod]
        public void ValidateItemIdParameter_ItemIdHasAValue_ReturnsTrue()
        {
            #region Arrange
            var externalService = new Mock<IExternalService>();
            var loggerService = new Mock<ILoggerService>();

            ItemDomain model = new ItemDomain(externalService.Object,loggerService.Object);

            #endregion

            #region Act

            var validate = model.ValidateItemIdParameter("exampleValue");

            #endregion

            #region Assert

            Assert.IsTrue(validate);

            #endregion

        }

        [TestMethod]
        public void GetItem_MockedExternalServiceWith1ItemIDxxx_ReturnsItemIDxxx()
        {
            #region Arrange

            const string itemId = "xxx";
            var mockedItem = new ItemEntity {id = itemId};

            var externalService = new Mock<IExternalService>();
            string externalServiceResponseMessage = string.Empty;
            externalService.Setup(m => m.GetItem(itemId,ref externalServiceResponseMessage))
                .Returns(mockedItem);
            var loggerService = new Mock<ILoggerService>();

            var model = new ItemDomain(externalService.Object, loggerService.Object);

            #endregion

            #region Act

            string responseMessage = string.Empty;
            var item = model.GetItem(itemId, ref responseMessage);

            #endregion

            #region Assert

            Assert.IsNotNull(item);
            Assert.AreEqual(itemId,item.id);

            #endregion

        }

        [TestMethod]
        public void ValidateSearchItemsParameters_FilterIsStringEmptyOffsetIsNullLimitIsNull_ReturnsFalse()
        {
            #region Arrange

            var externalService = new Mock<IExternalService>();
            var loggerService = new Mock<ILoggerService>();

            var model = new ItemDomain(externalService.Object,loggerService.Object);

            #endregion

            #region Act

            var validate = model.ValidateSearchItemsParameters(string.Empty, null, null);

            #endregion

            #region Assert

            Assert.IsFalse(validate);

            #endregion

        }

        [TestMethod]
        public void ValidateSearchItemsParameters_FilterHasAValueOffsetIsNullLimitIsNull_ReturnsTrue()
        {
            #region Arrange
            var externalService = new Mock<IExternalService>();
            var loggerService = new Mock<ILoggerService>();

            var model = new ItemDomain(externalService.Object, loggerService.Object);

            #endregion

            #region Act

            var validate = model.ValidateSearchItemsParameters("exampleValue", null, null);

            #endregion

            #region Assert

            Assert.IsTrue(validate);

            #endregion

        }

        [TestMethod]
        public void ValidateSearchItemsParameters_FilterHasAValueOffsetIsNegativeLimitIsNull_ReturnsFalse()
        {
            #region Arrange
            var externalService = new Mock<IExternalService>();
            var loggerService = new Mock<ILoggerService>();

            var model = new ItemDomain(externalService.Object, loggerService.Object);

            #endregion

            #region Act

            var validate = model.ValidateSearchItemsParameters("exampleValue", -1, null);

            #endregion

            #region Assert

            Assert.IsFalse(validate);

            #endregion

        }

        [TestMethod]
        public void ValidateSearchItemsParameters_FilterHasAValueOffsetIsNullLimitIsNegative_ReturnsFalse()
        {
            #region Arrange
            var externalService = new Mock<IExternalService>();
            var loggerService = new Mock<ILoggerService>();

            var model = new ItemDomain(externalService.Object, loggerService.Object);

            #endregion

            #region Act

            var validate = model.ValidateSearchItemsParameters("exampleValue", null, -1);

            #endregion

            #region Assert

            Assert.IsFalse(validate);

            #endregion

        }

        [TestMethod]
        public void SearchItems_MockedExternalServiceWith2Bicicletas_ReturnsResultWith2Bicicletas()
        {
            #region Arrange

            var mockedExternalServiceResult = new SearchResultEntity { results = new List<ItemResultEntity> { new ItemResultEntity(), new ItemResultEntity() } };

            const string filter = "bicicleta";

            var externalService = new Mock<IExternalService>();
            string externalServiceResponseMessage = string.Empty;
            externalService.Setup(m => m.SearchItems(filter, null, null,ref externalServiceResponseMessage))
                .Returns(mockedExternalServiceResult);
            var loggerService = new Mock<ILoggerService>();

            var model = new ItemDomain(externalService.Object, loggerService.Object);

            #endregion

            #region Act

            string responseMessage = string.Empty;
            var searchResult = model.SearchItems(filter, null, null, ref responseMessage);

            #endregion

            #region Assert

            Assert.AreEqual(2, searchResult.results.Count);

            #endregion

        }
    }
}
