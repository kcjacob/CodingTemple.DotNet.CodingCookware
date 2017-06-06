using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingTemple.CodingCookware.Web.Models
{
    public class CartProductModel : ProductModel
    {
        public int Quantity { get; set; }
    }
}