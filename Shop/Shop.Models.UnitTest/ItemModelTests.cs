using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shop.Models.UnitTest
{
    [TestClass]
    public class ItemModelTests
    {
        [TestMethod]
        public void ValidateItemIdParameter_ItemIdIsStringEmpty_ReturnsFalse()
        {
            #region Arrange

            ItemModel model = new ItemModel();

            #endregion

            #region Act

            var validate = model.ValidateItemIdParameter(string.Empty);

            #endregion

            #region Assert

            Assert.IsFalse(validate);

            #endregion

        }

        [TestMethod]
        public void ValidateItemIdParameter_ItemHasAValue_ReturnsTrue()
        {
            #region Arrange

            ItemModel model = new ItemModel();

            #endregion

            #region Act

            var validate = model.ValidateItemIdParameter("exampleValue");

            #endregion

            #region Assert

            Assert.IsTrue(validate);

            #endregion

        }
    }
}
