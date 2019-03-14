using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.Application;
using Shop.CrossCutting;
using Shop.DTOs;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using Shop.MVC.Controllers;

namespace Shop.MVC.UnitTest
{
    [TestClass]
    public class SearchControllerTests
    {
        [TestMethod]
        public void Index_MockedExternalServiceWith2Bicicletas_ReturnsView()
        {
            #region Arrange

            const string filter = "bicicleta";
            const int totalItemCount = 22;

            const string idItem1 = "bici1";
            const string titleItem1 = "SuperBici1";
            const decimal priceItem1 = 50;
            const string thumbnailItem1 = "www.google.com";
            const bool freeShippingItem1 = true;

            const string idItem2 = "bici2";
            const string titleItem2 = "SuperBici2";
            const decimal priceItem2 = 14123;
            const string thumbnailItem2 = "www.facebook.com";
            const bool freeShippingItem2 = false;

            var mockedExternalServiceResult = new SearchResultEntity
            {
                paging = new PagingEntity { total = totalItemCount },
                results = new List<ItemResultEntity>
                {
                    new ItemResultEntity{id = idItem1,title = titleItem1,price = priceItem1,thumbnail = thumbnailItem1,shipping = new ShippingEntity{free_shipping = freeShippingItem1}},
                    new ItemResultEntity{id = idItem2,title = titleItem2,price = priceItem2,thumbnail = thumbnailItem2,shipping = new ShippingEntity{free_shipping = freeShippingItem2}}
                }
            };



            var externalService = new Mock<IExternalService>();
            string externalServiceResponseMessage = string.Empty;
            externalService.Setup(m => m.SearchItems(filter, null, null, ref externalServiceResponseMessage))
                .Returns(mockedExternalServiceResult);
            var loggerService = new Mock<ILoggerService>();
            ItemApplication.MapperReset();
            var applicationItem = new ItemApplication(externalService.Object, loggerService.Object);

            var controller = new SearchController(applicationItem);
            #endregion

            #region Act

            var result = controller.Index(filter);

            #endregion

            #region Assert

            Assert.IsNotInstanceOfType(result,typeof(string));
            Assert.IsInstanceOfType(result,typeof(ViewResult));
            var resultItems = ((List<ItemResultDTO>) ((ViewResult) result).Model);
            Assert.AreEqual(2, resultItems.Count);

            Assert.AreEqual(idItem1, resultItems.Where(i => i.Id == idItem1).First().Id);
            Assert.AreEqual(titleItem1, resultItems.Where(i => i.Id == idItem1).First().Title);
            Assert.AreEqual(priceItem1, resultItems.Where(i => i.Id == idItem1).First().Price);
            Assert.AreEqual(thumbnailItem1, resultItems.Where(i => i.Id == idItem1).First().Thumbnail);
            Assert.AreEqual(freeShippingItem1, resultItems.Where(i => i.Id == idItem1).First().FreeShipping);

            Assert.AreEqual(idItem2, resultItems.Where(i => i.Id == idItem2).First().Id);
            Assert.AreEqual(titleItem2, resultItems.Where(i => i.Id == idItem2).First().Title);
            Assert.AreEqual(priceItem2, resultItems.Where(i => i.Id == idItem2).First().Price);
            Assert.AreEqual(thumbnailItem2, resultItems.Where(i => i.Id == idItem2).First().Thumbnail);
            Assert.AreEqual(freeShippingItem2, resultItems.Where(i => i.Id == idItem2).First().FreeShipping);

            #endregion


        }

        [TestMethod]
        public void Index_MockedExternalServiceEmpty_ReturnsContentResult()
        {
            #region Arrange

            const string filter = "bicicleta";
            
            var externalService = new Mock<IExternalService>();
            var loggerService = new Mock<ILoggerService>();
            ItemApplication.MapperReset();
            var applicationItem = new ItemApplication(externalService.Object, loggerService.Object);

            var controller = new SearchController(applicationItem);
            #endregion

            #region Act

            var result = controller.Index(filter);

            #endregion

            #region Assert

            Assert.IsInstanceOfType(result, typeof(ContentResult));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));

            #endregion


        }

        [TestMethod]
        public void Details_MockedExternalServiceWith1ItemIDxxx_ReturnsView()
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

            var mockedItem = new ItemEntity
            {
                id = itemId,
                price = price,
                title = title,
                sold_quantity = soldQuantity,
                available_quantity = availableQuantity,
                pictures = new List<PictureEntity> { new PictureEntity { url = url } },
                attributes = new List<ItemAttributeEntity> { new ItemAttributeEntity { name = attributeName, value_name = attributeValue } }
            };

            var mockedLargeDescription = new ItemLargeDescriptionEntity
            {
                plain_text = largeDescription,
                date_created = DateTime.Now,
                last_updated = DateTime.Now,
                snapshot = new SnapshotEntity { url = "", height = 0, status = "", width = 0 },
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
            ItemApplication.MapperReset();
            var applicationItem = new ItemApplication(externalService.Object, loggerService.Object);

            var controller = new SearchController(applicationItem);

            #endregion

            #region Act

            var result = controller.Details(itemId);

            #endregion

            #region Assert

            Assert.IsNotInstanceOfType(result, typeof(ContentResult));
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var item = ((ItemDTO)((ViewResult)result).Model);
            Assert.AreEqual(price, item.Price);
            Assert.AreEqual(title, item.Title);
            Assert.AreEqual(url, item.PicturesUrl.First());
            Assert.AreEqual(attributeName, item.Attributes.First().Item1);
            Assert.AreEqual(attributeValue, item.Attributes.First().Item2);
            Assert.AreEqual(availableQuantity, item.AvailableQuantity);
            Assert.AreEqual(soldQuantity, item.SoldQuantity);
            Assert.AreEqual(largeDescription, item.ItemLargeDescription);

            #endregion

        }

        [TestMethod]
        public void Details_MockedExternalServiceEmpty_ReturnsContentResult()
        {
            #region Arrange

            string itemId = "xxx";
            var externalService = new Mock<IExternalService>();
            var loggerService = new Mock<ILoggerService>();
            ItemApplication.MapperReset();
            var applicationItem = new ItemApplication(externalService.Object, loggerService.Object);

            var controller = new SearchController(applicationItem);

            #endregion

            #region Act

            var result = controller.Details(itemId);

            #endregion

            #region Assert

            Assert.IsInstanceOfType(result, typeof(ContentResult));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));

            #endregion

        }
    }
}
