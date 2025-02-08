using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sports_Store.Models;
using Sports_Store.Models.ModelInterfaces;

namespace Sports_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreInterface _interface;
    

        public HomeController(IStoreInterface inter)
        {
            _interface = inter;
        }

        public IActionResult Index(string? category, int page=1)
        {
            var filteredProducts = _interface.Products
                .Where(p => category == null || p.Category == category);

            int pageSize = 4;
            var totalItems = filteredProducts.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var products = filteredProducts
                .Skip((page-1) * pageSize)
                .Take(pageSize);

            var categories = _interface.Products
                .Select(p => p.Category)
                .Distinct();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Categories = categories;
            ViewBag.CurrentCategory = category;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_ProductListPartial", products);

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
