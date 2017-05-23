using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoeStore.Models;
namespace JoeStore.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            if (!Request.Cookies.AllKeys.Contains("cart"))
                return RedirectToAction("Index", "Cart");
            CheckoutModel model = new CheckoutModel();

            return View(model);
        }

        // POST: Checkout
        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            //TODO: Save the checkout information somewhere.
            return RedirectToAction("Index", "Reciept");
        }
    }
}