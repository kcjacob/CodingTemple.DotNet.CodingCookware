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
        public ActionResult Index(int? id, string productName)
        {
            if(id == 500)
            {
                return this.HttpNotFound("This doesn't exist");
            }

            //If id is 300, redirect to "Home" controller
            if(id == 300)
            {
                return Redirect("/");
                //return RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrEmpty(productName))
            {
                productName = "My Product";
            }
            var product = new { id = id, name = productName, price = 299m, description = "This is a product" };
            return Json(product, JsonRequestBehavior.AllowGet);
            
        }

        
        [HttpPost]
        public ActionResult Index(int? id)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}