using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Application;
using Shop.Application.Interfaces;
using Shop.CrossCutting;
using Shop.CrossCutting.Log;
using Shop.DTOs;
using Shop.Entities;
using Shop.ExternalServices;
using Shop.ExternalServices.Interfaces;
using Shop.Models;
using Shop.Models.Interfaces;

namespace Shop.MVC.Controllers
{
    public class ItemController : Controller
    {
        private IItemApplication _itemApplication;

        public ItemController(IItemApplication itemApplication)
        {
            _itemApplication = itemApplication;
        }

        // GET
        public IActionResult Index(string id)
        {
            string responseMessage = string.Empty;
            ItemDTO item = _itemApplication.GetItem(id, ref responseMessage);

            return View(item);
        }
    }
}