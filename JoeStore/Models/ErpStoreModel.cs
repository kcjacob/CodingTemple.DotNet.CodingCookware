using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoeStore.Models
{
    public class ErpStoreModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

    }
}