using Microsoft.AspNetCore.Mvc;
using Sports_Store.Models.ModelInterfaces;
using Sports_Store.Services;

namespace Sports_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly IStoreInterface _storeService;
        private readonly CartService _cartService;

        public CartController(IStoreInterface storeService, CartService cartService)
        {
            _storeService = storeService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(long productId, int quantity)
        {
            var product = _storeService.GetProductById(productId);
            if (product == null)
                return RedirectToAction("Error", "Home");

            var cart = _cartService.GetCart();
            cart.AddItem(product, quantity);
            _cartService.SaveCart(cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(long productId)
        {
            var cart = _cartService.GetCart();
            cart.RemoveItem(productId);
            _cartService.SaveCart(cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            var cart = _cartService.GetCart();
            cart.Clear();
            _cartService.SaveCart(cart);

            return RedirectToAction("Index");
        }
    }
}