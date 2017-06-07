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
            filterContext.Controller.ViewBag.CartItemCount = 0;
            
            if (filterContext.RequestContext.HttpContext.Request.Cookies.AllKeys.Contains("cart"))
            {
                int cartId = int.Parse(filterContext.RequestContext.HttpContext.Request.Cookies["cart"].Value);
                using (Models.CodingCookwareEntities entities = new Models.CodingCookwareEntities())
                {
                    var basket = entities.Baskets.Find(cartId);
                    filterContext.Controller.ViewBag.CartItemCount = basket.BasketProducts.Sum(x => x.Quantity);
                }

            }
                   
        }

        //This happens before the controller method is called
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}