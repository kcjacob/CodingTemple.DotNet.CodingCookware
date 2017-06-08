using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodingTemple.CodingCookware.Web.Models;
namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class CheckoutController : CodingCookwareController
    {
        public ActionResult Index()
        {
            CheckoutModel model = new CheckoutModel();
            model.Basket = CurrentBasket;
            model.SavedAddresses = User.Identity.IsAuthenticated ? entities.AspNetUsers.Single(x => x.UserName == User.Identity.Name).Addresses : new Address[0];
            return View(model);
        }

        // POST: Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CheckoutModel model, string paymentMethodNonce)
        {
            //Check if the model-state is valid -- this will catch anytime someone hacks your client-side validation
            if (ModelState.IsValid)
            {

                Shipment s = new Shipment
                {
                    AddressLine1 = model.ShippingAddressLine1,
                    AddressLine2 = model.ShippingAddressLine2,
                    City = model.ShippingCity,
                    State = model.ShippingState,
                    PostalCode = model.ShippingPostalCode,
                    Country = model.ShippingCountry,
                    Modified = DateTime.UtcNow,
                    Created = DateTime.UtcNow
                };
     

                Purchase p = new Purchase
                {
                    SubmittedDate = DateTime.UtcNow,
                    AspNetUserID = User.Identity.IsAuthenticated ? entities.AspNetUsers.First(x => x.UserName == User.Identity.Name).Id : null,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    OrderIdentifier = Guid.NewGuid().ToString().Substring(0, 8),
                    PurchaseProducts = CurrentBasket.BasketProducts.Select(x => new Models.PurchaseProduct
                    {
                        ProductID = x.ProductID,
                        Quantity = x.Quantity,
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow,
                        ProductName = x.Product.Name,
                        ProductPrice = x.Product.Price,
                        Shipment = s,
                    }).ToArray()
                };

                
                entities.Purchases.Add(p);

                entities.Baskets.Remove(CurrentBasket);
                entities.SaveChanges();
                return RedirectToAction("Index", "Reciept", new { id = p.OrderIdentifier });
            }
            return View(CurrentBasket);
        }
    }
}