using CodingTemple.CodingCookware.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class CartController : CodingCookwareController
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View(CurrentBasket);
        }

        // POST: Cart
        [HttpPost]
        public ActionResult Index(Basket model)
        {

            var basket = CurrentBasket;
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