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
                return View(entities.Categories.Find(id));
            }
            return View(new Models.Category
            {
                Category1 = entities.Categories.Where(x => x.Category2 == null).ToList(),
                Products = entities.Products.Where(x => !x.Categories.Any()).ToList(),
                ID = ""
            });
        }
    }
}