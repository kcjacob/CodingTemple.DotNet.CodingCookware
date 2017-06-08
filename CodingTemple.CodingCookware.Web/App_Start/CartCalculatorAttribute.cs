using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web
{
    public class CartCalculatorAttribute : FilterAttribute, IActionFilter
    {
        //This happens after the controller method is called
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

            using (Models.CodingCookwareEntities entities = new Models.CodingCookwareEntities())
            {
                Models.Basket b = null;
                if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    b = entities.AspNetUsers.FirstOrDefault(x => x.UserName == filterContext.HttpContext.User.Identity.Name).Baskets.FirstOrDefault();
                }
                else if (filterContext.HttpContext.Request.Cookies.AllKeys.Contains("cart"))
                {
                    int cartId = int.Parse(filterContext.HttpContext.Request.Cookies["cart"].Value);
                    b = entities.Baskets.Find(cartId);
                }

                if (b == null)
                {
                    filterContext.Controller.ViewBag.CartItemCount = 0;
                }
                else
                {
                    filterContext.Controller.ViewBag.CartItemCount = b.BasketProducts.Sum(x => x.Quantity);
                }
            }
        }
        
        //This happens before the controller method is called
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }

}