using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoeStore.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        [OutputCache(Duration = 300)]
        public ActionResult Index(int? id)
        {
            if (!Models.ProductData.Products.Any(x => x.ID == id))
            {
                return HttpNotFound("Product doesn't exist");
            }
            else
            {
                return View(Models.ProductData.Products.First(x => x.ID == id));
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
        public ActionResult Index(Models.ProductModel model, int? quantity)
        {
            //TODO: add this product to the current user's cart
            HttpCookie cookie = new HttpCookie("cart", model.ID.ToString() + "," + quantity.Value.ToString());
            Response.SetCookie(cookie);
            return RedirectToAction("Index", "Cart");
        }
    }
}