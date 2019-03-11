using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;

namespace Shop.Models.UnitTest
{
    [TestClass]
    public class SearchModelTests
    {        
        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [TestMethod]
        public void ValidateSearchItemsParameters_FilterIsStringEmptyOffsetIsNullLimitIsNull_ReturnsFalse()
        {
            #region Arrange

            var externalService = new Mock<IExternalService>();
            //_externalService.Setup(m => m.GetItem(It.IsAny<string>()))
            //    .Returns(new Item());

            SearchModel model = new SearchModel(externalService.Object);

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
            var model = new SearchModel(externalService.Object);

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
            var model = new SearchModel(externalService.Object);

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
            var model = new SearchModel(externalService.Object);

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

            var mockedExternalServiceResult = new SearchResult {results = new List<Result> {new Result(), new Result()}};

            const string filter = "bicicleta";

            var externalService = new Mock<IExternalService>();
            externalService.Setup(m => m.SearchItems(filter, null,null))
                .Returns(mockedExternalServiceResult);

            var model = new SearchModel(externalService.Object);

            #endregion

            #region Act

            var searchResult = model.SearchItems(filter, null, null);

            #endregion

            #region Assert

            Assert.AreEqual(2, searchResult.results.Count);

            #endregion

        }


    }
}
