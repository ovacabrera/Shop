using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.CrossCutting;
using Shop.CrossCutting.Log;
using Shop.Entities;
using Shop.ExternalServices;
using Shop.ExternalServices.Interfaces;
using Shop.Models;
using Shop.Models.Interfaces;

namespace Shop.Controllers
{
    public class SearchController : Controller
    {
        private int _itemsPerPage = 50;

        public IActionResult Search(string q)
        {
            return Search(q, 1);
        }

        public IActionResult Search(string q, int p)
        {            
            IExternalService externalService = new ExternalServiceMercadoLibre();
            ILoggerService loggerService = new Log4NetLoggerService();
            IItemModel model = new ItemModel(externalService, loggerService);

            loggerService.Action("UserX", "VER CCOMO OBTENEMOS ESTO", System.Reflection.MethodBase.GetCurrentMethod().Name, DateTime.Now);

            SearchResult searchResult = model.SearchItems(q, (p - 1) * _itemsPerPage, _itemsPerPage);
            if (searchResult != null && searchResult.results.Count > 0)
            {
                return View(searchResult.results);
            }
            else
            {
                return null;
            }
        }
    }
}