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
                return View(basket);
            }

            return View(new Basket  { BasketProducts = new BasketProduct[0] });
        }

        // POST: Cart
        [HttpPost]
        public ActionResult Index(Basket model)
        {

            HttpCookie cartCookie = Request.Cookies["cart"];
            //CartCookie comes in with "2,1", meaning productId = 2, quantity = 1
            int cartId = int.Parse(Request.Cookies["cart"].Value);
            var basket = entities.Baskets.Find(cartId);
            foreach(var updatedProduct in model.BasketProducts)
            {
                var product = basket.BasketProducts.FirstOrDefault(x => x.ProductID == updatedProduct.ProductID);
                if(product != null)
                {
                    product.Quantity = updatedProduct.Quantity;
                    product.Modified = DateTime.UtcNow;
                }
            }
            entities.SaveChanges();
            entities.BasketProducts.RemoveRange(basket.BasketProducts.Where(x => x.Quantity == 0));
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}