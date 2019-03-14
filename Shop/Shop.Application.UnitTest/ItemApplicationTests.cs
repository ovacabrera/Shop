using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.CrossCutting;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;

namespace Shop.Application.UnitTest
{
    [TestClass]
    public class ItemApplicationTests
    {
        [TestMethod]
        public void GetItem_MockedExternalServiceWith1ItemIDxxx_ReturnsItemIDxxx()
        {
            #region Arrange

            string itemId = "xxx";
            const decimal price = 55;
            const string title = "Article Title";
            const string largeDescription = "This is my large description";
            const string url = "www.google.com";
            const string attributeName = "CaracteristicaA";
            const string attributeValue = "ValorDeCaracteristicaA";
            const int soldQuantity = 5;
            const int availableQuantity = 10;

        var mockedItem = new ItemEntity { 
                                                id = itemId,
                                                price = price,
                                                title = title,
                                                sold_quantity = soldQuantity,
                                                available_quantity = availableQuantity,                                                
                                                pictures = new List<PictureEntity>{new PictureEntity{url=url}},
                                                attributes = new List<ItemAttributeEntity> {new ItemAttributeEntity{name = attributeName,value_name = attributeValue}}
            };

        var mockedLargeDescription = new ItemLargeDescriptionEntity
        {
            plain_text = largeDescription,
            date_created = DateTime.Now,
            last_updated = DateTime.Now,
            snapshot = new SnapshotEntity {url = "", height = 0, status = "", width = 0},
            text = ""
        };

            var externalService = new Mock<IExternalService>();
            string externalServiceResponseMessage = string.Empty;
            externalService
                .Setup(m => m.GetItemLargeDescription(itemId, ref externalServiceResponseMessage))
                .Returns(mockedLargeDescription);
            externalService
                .Setup(m => m.GetItem(itemId, ref externalServiceResponseMessage))
                .Returns(mockedItem);
            var loggerService = new Mock<ILoggerService>();

            var applicationItem = new ItemApplication(externalService.Object, loggerService.Object);

            #endregion

            #region Act

            string responseMessage = string.Empty;
            var item = applicationItem.GetItem(itemId, ref responseMessage);

            #endregion

            #region Assert

            Assert.IsNotNull(item);
            Assert.AreEqual(price, item.Price);
            Assert.AreEqual(title, item.Title);
            Assert.AreEqual(url, item.PicturesUrl.First());
            Assert.AreEqual(attributeName, item.Attributes.First().Item1);
            Assert.AreEqual(attributeValue, item.Attributes.First().Item2);
            Assert.AreEqual(availableQuantity,item.AvailableQuantity);
            Assert.AreEqual(soldQuantity,item.SoldQuantity);
            Assert.AreEqual(largeDescription, item.ItemLargeDescription);

            #endregion

        }
    }
}
