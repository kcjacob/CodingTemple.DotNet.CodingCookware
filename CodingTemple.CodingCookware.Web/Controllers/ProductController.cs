using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodingTemple.CodingCookware.Web.Models;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class ProductController : Controller
    {
        CodingCookwareEntities entities = new CodingCookwareEntities();
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
         

            //Returning JSON is great for passing server-side data back to client-side scripts like Angular or jQuery
            //return Json(product, JsonRequestBehavior.AllowGet);   

            //Returning Redirects are how I can move people to other pages
            //return Redirect("/");
            //return RedirectToAction("Index", "Home");

            //Return not found replies with a 404 error.
            //return this.HttpNotFound("This doesn't exist");

            //Returning a view will serve up an HTML-based document to the end user which will include my controller data


        [HttpPost]
        public ActionResult Index(Models.Product model, int? quantity)
        {
            //TODO: add this product to the current user's cart
            Basket b = null;
            if (User.Identity.IsAuthenticated)
            {
                b = entities.AspNetUsers.FirstOrDefault(x => x.UserName == User.Identity.Name).Baskets.FirstOrDefault();
            }
            else if (Request.Cookies.AllKeys.Contains("cart"))
            {
                int cartId = int.Parse(Request.Cookies["cart"].Value);
                b = entities.Baskets.Find(cartId);
            }

            if (b == null)
            {
                b = new Basket();
                b.Created = DateTime.UtcNow;
                b.Modified = DateTime.UtcNow;
                if (User.Identity.IsAuthenticated)
                {
                    b.AspNetUserID = entities.AspNetUsers.FirstOrDefault(x => x.UserName == User.Identity.Name).Id;
                }
                entities.Baskets.Add(b);
                entities.SaveChanges();
                Response.Cookies.Add(new HttpCookie("cart", b.ID.ToString()));
            }
            BasketProduct p = b.BasketProducts.FirstOrDefault(x => x.ProductID == model.ID);
            if(p != null)
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

        protected override void Dispose(bool disposing)
        {
            entities.Dispose();
            base.Dispose(disposing);
        }
    }
}