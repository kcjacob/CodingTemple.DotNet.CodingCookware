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
        CodingCookwareEntities entities = new CodingCookwareEntities();
        protected override void Dispose(bool disposing)
        {
            entities.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            
            if (Request.Cookies.AllKeys.Contains("cart"))
            {
                HttpCookie cartCookie = Request.Cookies["cart"];
                //CartCookie comes in with "2,1", meaning productId = 2, quantity = 1
                int cartId = int.Parse(Request.Cookies["cart"].Value);
                var basket = entities.Baskets.Find(cartId);
                return View(basket.BasketProducts);
            }

            return View(new BasketProduct[0]);
        }

        // POST: Cart
        [HttpPost]
        public ActionResult Index(BasketProduct[] model, int? quantity)
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