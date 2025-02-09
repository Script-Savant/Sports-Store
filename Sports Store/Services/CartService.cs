using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sports_Store.Models;

namespace Sports_Store.Services{
    public class CartService{
        private const string CartSessionKey = "Cart";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor){
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart(){
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString(CartSessionKey);

            return cartJson == null ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartJson);
        }

        public void SaveCart(Cart cart){
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString(CartSessionKey, JsonConvert.SerializeObject(cart));
        }
    }
}