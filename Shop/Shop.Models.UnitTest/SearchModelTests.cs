using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shop.Models.UnitTest
{
    [TestClass]
    public class SearchModelTests
    {
        [TestMethod]
        public void ValidateSearchItemsParameters_FilterIsStringEmptyOffsetIsNullLimitIsNull_ReturnsFalse()
        {
            #region Arrange

            SearchModel model = new SearchModel();

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

            SearchModel model = new SearchModel();

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

            SearchModel model = new SearchModel();

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

            SearchModel model = new SearchModel();

            #endregion

            #region Act

            var validate = model.ValidateSearchItemsParameters("exampleValue", null, -1);

            #endregion

            #region Assert

            Assert.IsFalse(validate);

            #endregion

        }
    }
}
