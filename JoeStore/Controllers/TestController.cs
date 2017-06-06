using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return Json("No value provided", JsonRequestBehavior.AllowGet);
            }
            var result = "";
            if(id > 0)
            {
                result = "Number is positive";
            }
            else
            {
                result = "Number is negative";
            }
            result = (id > 0) ? "Number is positive" : "Number is negative";
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}