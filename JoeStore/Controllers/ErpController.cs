using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingTemple.CodingCookware.Web.Controllers
{
    public class ErpController : Controller
    {
        // GET: Erp
        /// <summary>
        /// Calls the "sp_GetStores" stored procedure, and displays the results in the view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ERP"].ConnectionString;
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
            connection.Open();

            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
            command.CommandText = "sp_GetStores";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            List<Models.ErpStoreModel> stores = new List<Models.ErpStoreModel>();

            while (reader.Read())
            {
                Models.ErpStoreModel store = new Models.ErpStoreModel();
                //the reader is "untyped"
                // I need to look at the stored procedure definition to see that the 1st column returned is an int
                store.ID = reader.GetInt32(0); 
                store.Name = reader.GetString(1);
                //Add the newly created store to the list
                stores.Add(store);
            }
            connection.Close();
            
            return View(stores);
        }

        /// <summary>
        /// Calls the "sp_GetStoreRevenue" stored procedure
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Revenues(int? id)
        {

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ERP"].ConnectionString;
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
            connection.Open();
            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
            command.CommandText = "sp_GetStoreRevenue";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            System.Data.SqlClient.SqlParameter parameter = command.CreateParameter();
            parameter.Direction = System.Data.ParameterDirection.Input;
            parameter.ParameterName = "@store";
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            parameter.SqlValue = id;

            command.Parameters.Add(parameter);

            List<Models.ErpRevenueModel> revenues = new List<Models.ErpRevenueModel>();
            System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Models.ErpRevenueModel revenue = new Models.ErpRevenueModel();
                revenue.Revenue = reader.GetDecimal(0);
                revenue.Date = new DateTime(reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));

                revenues.Add(revenue);
            }
            connection.Close();

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