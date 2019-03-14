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
            var searchResult = _itemApplication.SearchItems(filter,null,null, ref responseMessage);

            if (searchResult == null)
            {
                return Content(responseMessage);
            }

            if (searchResult.Results.Count > 0)
            {
                return View(searchResult.Results);
            }
            else
            {
                return Content("No hay ítems que coincidan con tu búsqueda.");
            }
            
        }

        // GET: Search/Details/5
        public ActionResult Details(string id)
        {
            string responseMessage = string.Empty;
            ItemDTO item = _itemApplication.GetItem(id, ref responseMessage);

            if (item != null)
            {
                return View(item);
            }
            else
            {
                return Content(responseMessage);
            }
                    
            
        }

    }
}