using System;
using Microsoft.AspNetCore.Mvc;
using Shop.CrossCutting;
using Shop.CrossCutting.Log;
using Shop.Entities;
using Shop.ExternalServices;
using Shop.ExternalServices.Interfaces;
using Shop.Models;
using Shop.Models.Interfaces;

namespace Shop.MVC.Controllers
{
    public class ItemController : Controller
    {
        // GET
        public IActionResult Index(string id)
        {
            IExternalService externalService = new ExternalServiceMercadoLibre();
            ILoggerService loggerService = new Log4NetLoggerService();
            IItem model = new Item(externalService, loggerService);

            loggerService.Action("UserX", "VER CCOMO OBTENEMOS ESTO", System.Reflection.MethodBase.GetCurrentMethod().Name, DateTime.Now);

            ItemEntity item = model.GetItem(id);

            return View(item);
        }
    }
}