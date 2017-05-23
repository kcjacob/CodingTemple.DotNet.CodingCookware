using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoeStore.Models
{
    public class CartProductModel : ProductModel
    {
        public int Quantity { get; set; }
    }
}