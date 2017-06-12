using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class AccountController : Controller
    {
        //Declaratively allow only users who are logged in:
        [Authorize]
        public ActionResult Index()
        {
            //Explicitly redirecting is ok:
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("LogOn");
            //}
            return View();
        }


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
            var user = new Microsoft.AspNet.Identity.EntityFramework.IdentityUser() { UserName = username, Email = email, EmailConfirmed = false };

            manager.UserTokenProvider = 
                new Microsoft.AspNet.Identity.EmailTokenProvider<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>();

            Microsoft.AspNet.Identity.IdentityResult result = await manager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                //I have some options: log them in, or I can send them an email to "Confirm" their account details.'
                //I don't have email set up this week, so we'll come back to that.
                string confirmationToken = await manager.GenerateEmailConfirmationTokenAsync(user.Id);

                string confirmationLink = Request.Url.GetLeftPart(UriPartial.Authority) + "/Account/Confirm/" + user.Id + "?token=" + confirmationToken;

                string apiKey = System.Configuration.ConfigurationManager.AppSettings["SendGrid.ApiKey"];

                SendGrid.ISendGridClient client = new SendGrid.SendGridClient(apiKey);
                SendGrid.Helpers.Mail.EmailAddress from = new SendGrid.Helpers.Mail.EmailAddress("admin@codingcookware.com", "Coding Cookware Administrator");

                SendGrid.Helpers.Mail.EmailAddress to = new SendGrid.Helpers.Mail.EmailAddress(email);

                string subject = "Confirm your Coding Cookware Account";

                string htmlContent = string.Format("<a href=\"{0}\">Confirm Your Account</a>", confirmationLink);
                string plainTextContent = confirmationLink;

                SendGrid.Helpers.Mail.SendGridMessage message = SendGrid.Helpers.Mail.MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                SendGrid.Response response = await client.SendEmailAsync(message);
                TempData["EmailAddress"] = email;

                return RedirectToAction("ConfirmationSent");


                //Commenting this out: I'm not going to log the user in on registration anymore - I'm going to send them a confirmation email instead.
                //This authentication manager will create a cookie for the current user, and that cookie will be exchanged on each request until the user logs out
                //var authenticationManager = HttpContext.GetOwinContext().Authentication;
                //var userIdentity = await manager.CreateIdentityAsync(user, Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
                //authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { }, userIdentity);
            }
            else
            {
                ViewBag.Error = result.Errors;
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ConfirmationSent()
        {
            return View();
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
        public async System.Threading.Tasks.Task<ActionResult> LogOn(string username, string password, bool? staySignedIn, string returnUrl)
        {

            var userStore = new Microsoft.AspNet.Identity.EntityFramework.UserStore<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>();
            var manager = new Microsoft.AspNet.Identity.UserManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>(userStore);

            

            var user = await manager.FindByNameAsync(username);

            
            bool result = await manager.CheckPasswordAsync(user, password);
            if (result )
            {
                if (user.EmailConfirmed)
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
                    ViewBag.Error = new string[] { "Your email address has not been confirmed." };
                    return View();
                }
            }
            else
            {
                ViewBag.Error = new string[] {"Unable to Log In, check your username and password"};
                return View();
            }
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(returnUrl);
            }

        }

        public async System.Threading.Tasks.Task<ActionResult> Confirm(string id, string token)
        {
            var userStore = new Microsoft.AspNet.Identity.EntityFramework.UserStore<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>();
            var manager = new Microsoft.AspNet.Identity.UserManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>(userStore);
            manager.UserTokenProvider =
                new Microsoft.AspNet.Identity.EmailTokenProvider<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>();


            var result = await manager.ConfirmEmailAsync(id, token);
            if (result.Succeeded)
            {
                TempData["Confirmed"] = true;
                return RedirectToAction("LogOn");
            }
            else
            {
                return HttpNotFound();
            }


        }

        /// <summary>
        /// Display a form for a user to enter their username / email address
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgotPassword()
        {
            return View();
        }
        
        /// <summary>
        /// Validate the posted information and send an email with a reset token
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            return RedirectToAction("ResetPasswordSent");
        }


        /// <summary>
        /// Simple - Return a view
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPasswordSent()
        {
            return View();
        }

        //validate the reset token and display a form if it is valid
        public ActionResult ResetPassword(string token)
        {
            return View();
        }

        public ActionResult ResetPassword(string token, string newPassword)
        {

            return RedirectToAction("LogOn");
        }
    }
}