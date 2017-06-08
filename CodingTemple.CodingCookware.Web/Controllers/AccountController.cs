using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Register(string username, string email, string password)
        {
            var userStore = new Microsoft.AspNet.Identity.EntityFramework.UserStore<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>();
            var manager = new Microsoft.AspNet.Identity.UserManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>(userStore);
            var user = new Microsoft.AspNet.Identity.EntityFramework.IdentityUser() { UserName = username, Email = email, EmailConfirmed = true };
           
            Microsoft.AspNet.Identity.IdentityResult result = await manager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                //I have some options: log them in, or I can send them an email to "Confirm" their account details.'
                //I don't have email set up this week, so we'll come back to that.

                //This authentication manager will create a cookie for the current user, and that cookie will be exchanged on each request until the user logs out
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = await manager.CreateIdentityAsync(user, Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { }, userIdentity);
            }
            else
            {
                ViewBag.Error = result.Errors;
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        // GET Account/LogOff
        public ActionResult LogOff()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        // GET Account/LogOn
        public ActionResult LogOn()
        {
            return View();
        }

        // POST Account/LogOn
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> LogOn(string username, string password, bool? staySignedIn)
        {

            var userStore = new Microsoft.AspNet.Identity.EntityFramework.UserStore<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>();
            var manager = new Microsoft.AspNet.Identity.UserManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>(userStore);
            var user = await manager.FindByNameAsync(username);
            bool result = await manager.CheckPasswordAsync(user, password);
            if (result)
            {
                //I have some options: log them in, or I can send them an email to "Confirm" their account details.'
                //I don't have email set up this week, so we'll come back to that.

                //This authentication manager will create a cookie for the current user, and that cookie will be exchanged on each request until the user logs out
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = await manager.CreateIdentityAsync(user, Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { }, userIdentity);
            }
            else
            {
                ViewBag.Error = new string[] {"Unable to Log In, check your username and password"};
                return View();
            }

            return RedirectToAction("Index", "Home");

        }
    }
}