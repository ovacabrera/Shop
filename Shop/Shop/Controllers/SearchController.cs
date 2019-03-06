using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using Shop.Models;

namespace Shop.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Search(string q)
        {
            IItemModel model = new ItemModel();
            SearchResult searchResult = model.GetItems(q);
            return View(searchResult.results);
        }
    }
}