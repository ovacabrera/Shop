using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;
using Shop.DTOs;

namespace Shop.MVC.Controllers
{
    public class SearchController : Controller
    {
        private IItemApplication _itemApplication;
        // GET: Search

        public SearchController(IItemApplication itemApplication)
        {
            _itemApplication = itemApplication;
        }

        // GET
        public IActionResult Index(string filter)
        {
            string responseMessage = string.Empty;
            SearchResultDTO searchResult = _itemApplication.SearchItems(filter,null,null, ref responseMessage);
            return View(searchResult.Results);
        }

        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}