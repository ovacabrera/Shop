using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class ItemController : Controller
    {
        // GET: Item
        public IActionResult Item(string id)
        {            
            IExternalService externalService = new ExternalServiceMercadoLibre();
            ILoggerService loggerService = new Log4NetLoggerService();
            IItemModel model = new ItemModel(externalService, loggerService);

            loggerService.Action("UserX", "VER CCOMO OBTENEMOS ESTO", System.Reflection.MethodBase.GetCurrentMethod().Name, DateTime.Now);

            Item item = model.GetItem(id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return null;
            }                                
        }

        //// GET: Item
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Item/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Item/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Item/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Item/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Item/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Item/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Item/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}