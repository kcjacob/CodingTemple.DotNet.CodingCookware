using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoeStore.Models
{
    //This is how models are typically defined - just a bunch of properties, no (or few) methods.  
    //Sometimes referred to as DTOs (Data Transfer Objects), or POCOs (Plain Old CLR Objects).
    
    public class ProductModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }


    }

    //TODO: this is test data to get everything working - eventually I'm going to put this in a database
    public class ProductData
    {
        public static List<ProductModel> Products;
        static ProductData()
        {
            Products = new List<ProductModel>();
            Products.Add(new ProductModel { ID = 1, Description = "This cast-iron skillet provides even heat distribution and is oven safe", Name = "12\" iron skillet", Price = 32.99m });
            Products.Add(new ProductModel { ID = 2, Description = "The 10\" aluminum pan is lightweight and easy to clean", Name = "10\" Aluminum Pan", Price = 18.99m });
        }

    }
}