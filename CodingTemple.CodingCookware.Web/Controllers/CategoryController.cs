using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string id)
        {
            //if (!string.IsNullOrEmpty(id))
            //{
            //    return View(Models.ProductData.Products.Where(x => x.Category == id));
            //}
            return View(Models.ProductData.Products);
        }
    }
}