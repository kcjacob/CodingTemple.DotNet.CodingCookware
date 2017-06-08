using CodingTemple.CodingCookware.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class CodingCookwareController : Controller
    {

        protected CodingCookwareEntities entities = new CodingCookwareEntities();
        protected override void Dispose(bool disposing)
        {
            entities.Dispose();
            base.Dispose(disposing);
        }

        protected Basket CurrentBasket
        {
            get
            {
                Basket b = null;
                if (User.Identity.IsAuthenticated)
                {
                    b = entities.AspNetUsers.FirstOrDefault(x => x.UserName == User.Identity.Name).Baskets.FirstOrDefault();
                }
                else if (Request.Cookies.AllKeys.Contains("cart"))
                {
                    int cartId = int.Parse(Request.Cookies["cart"].Value);
                    b = entities.Baskets.Find(cartId);
                }

                if (b == null)
                {
                    b = new Basket();
                    b.Created = DateTime.UtcNow;
                    b.Modified = DateTime.UtcNow;
                    if (User.Identity.IsAuthenticated)
                    {
                        b.AspNetUserID = entities.AspNetUsers.FirstOrDefault(x => x.UserName == User.Identity.Name).Id;
                    }
                    entities.Baskets.Add(b);
                    entities.SaveChanges();
                    if (!User.Identity.IsAuthenticated)
                    {
                        Response.Cookies.Add(new HttpCookie("cart", b.ID.ToString()));
                    }
                }

                return b;
            }
        }


    }
}