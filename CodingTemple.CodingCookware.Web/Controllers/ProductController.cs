using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodingTemple.CodingCookware.Web.Models;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class ProductController : CodingCookwareController
    {
        // GET: Product
        //[OutputCache(Duration = 300)]
        public ActionResult Index(int? id)
        {
            
            if (!entities.Products.Any(x => x.ID == id))
            {
                return HttpNotFound("Product doesn't exist");
            }
            else
            {
                return View(entities.Products.Find(id));
            }
        }
         
        
        [HttpPost]
        public ActionResult Index(Models.Product model, int? quantity)
        {

            Basket b = CurrentBasket;
            BasketProduct p = b.BasketProducts.FirstOrDefault(x => x.ProductID == model.ID);
            if (p != null)
            {
                p.Quantity += quantity ?? 1;
            }
            else
            {
                p = new BasketProduct
                {
                    ProductID = model.ID,
                    Quantity = quantity ?? 1,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow
                };
                b.BasketProducts.Add(p);
            }
            b.Modified = DateTime.UtcNow;
            entities.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
        
    }
}