using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class CategoryController : Controller
    {
        CodingCookware.Web.Models.CodingCookwareEntities entities = new Models.CodingCookwareEntities();
        protected override void Dispose(bool disposing)
        {
            entities.Dispose();
            base.Dispose(disposing);
        }
        // GET: Category
        public ActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View(entities.Categories.Find(id).CategoryProducts.Select(x => x.Product));
            }
            return View(entities.Products);
        }
    }
}