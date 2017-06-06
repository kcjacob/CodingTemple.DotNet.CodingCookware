using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class ErpController : Controller
    {
        Areas.Admin.Models.ERPEntities entities = new Areas.Admin.Models.ERPEntities();
        // GET: Erp
        /// <summary>
        /// Calls the "sp_GetStores" stored procedure, and displays the results in the view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var stores = entities.sp_GetStores().Select(x => new Models.ErpStoreModel
            {
                Name =  x.Name,
                ID = x.ID
            });
            return View(stores);
        }

        /// <summary>
        /// Calls the "sp_GetStoreRevenue" stored procedure
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Revenues(int? id)
        {
            var revenues = entities.sp_GetStoreRevenue(id).Select(x => 
            new Models.ErpRevenueModel
            {
                Date = new DateTime(x.Year ?? 1900, x.Month ?? 1, x.Day ?? 1),
                Revenue = x.TotalRevenue ?? 0m
            });
            

            return View(revenues);
        }

        public ActionResult Schedule(int? id, DateTime? day)
        {
            if (!day.HasValue)
            {
                day = DateTime.Today;
            }
            //TODO: call the sp_GetEmployeesWorking procedure

            return View();
        }

        public ActionResult Add()
        {
            //TODO: Create a view that includes a "Form" and use the HTML helper to render editable fields
            return View();
        }

        [HttpPost]
        public ActionResult Add(Models.ErpStoreModel model)
        {
            //TODO: Insert the data from the model into the database using the "ExecuteNonQuery" method on SqlCommand.
            return RedirectToAction("Index");
        }
    }
}