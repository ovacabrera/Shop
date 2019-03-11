using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;

namespace Shop.Models.UnitTest
{
    [TestClass]
    public class ItemModelTests
    {
        [TestMethod]
        public void ValidateItemIdParameter_ItemIdIsStringEmpty_ReturnsFalse()
        {
            #region Arrange
            var externalService = new Mock<IExternalService>();
            ItemModel model = new ItemModel(externalService.Object);

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
            ItemModel model = new ItemModel(externalService.Object);

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
            var mockedItem = new Item {id = itemId};

            var externalService = new Mock<IExternalService>();
            externalService.Setup(m => m.GetItem(itemId))
                .Returns(mockedItem);

            var model = new ItemModel(externalService.Object);

            #endregion

            #region Act

            var item = model.GetItem(itemId);

            #endregion

            #region Assert

            Assert.IsNotNull(item);
            Assert.AreEqual(itemId,item.id);

            #endregion

        }
    }
}
