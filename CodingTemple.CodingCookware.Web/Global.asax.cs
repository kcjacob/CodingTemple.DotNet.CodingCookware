using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CodingTemple.CodingCookware.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //Set up some roles:

            var roleManager = new Microsoft.AspNet.Identity.EntityFramework.RoleStore<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>();


            var adminRole = roleManager.FindByNameAsync("Administrator").Result;
            if (adminRole == null)
            {
                var task = roleManager.CreateAsync(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Administrator" });

                task.RunSynchronously();
            }

        }


    }
}
