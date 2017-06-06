using CodingTemple.CodingCookware.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        
        public ActionResult Index()
        {
            List<CartProductModel> cartProducts = new List<CartProductModel>();
            if (Request.Cookies.AllKeys.Contains("cart"))
            {
                HttpCookie cartCookie = Request.Cookies["cart"];
                //CartCookie comes in with "2,1", meaning productId = 2, quantity = 1
                var cookieValues = cartCookie.Value.Split(',');
                int productId = int.Parse(cookieValues[0]);
                int quantity = int.Parse(cookieValues[1]);
                ProductModel product = ProductData.Products
                    .First(x => x.ID == productId);
                CartProductModel cartProduct = new CartProductModel();
                cartProduct.Description = product.Description;
                cartProduct.ID = product.ID;
                cartProduct.Name = product.Name;
                cartProduct.Price = product.Price;
                cartProduct.Quantity = quantity;

                cartProducts.Add(cartProduct);
            }

            return View(cartProducts);
        }

        // POST: Cart
        [HttpPost]
        public ActionResult Index(CartProductModel[] model, int? quantity)
        {

            HttpCookie cartCookie = Request.Cookies["cart"];
            //CartCookie comes in with "2,1", meaning productId = 2, quantity = 1
            var cookieValues = cartCookie.Value.Split(',');
            int productId = int.Parse(cookieValues[0]);
            cartCookie.Value = productId + "," + quantity.Value;
  
            //If the quantity is 0 or null, expire the cookie - in effect, this will remove everything from the cart
            if(quantity == null || quantity.Value < 1)
            {
                cartCookie.Expires = DateTime.UtcNow;
            }
            Response.SetCookie(cartCookie);
            return RedirectToAction("Index");
        }
    }
}