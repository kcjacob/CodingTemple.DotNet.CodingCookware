﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingTemple.CodingCookware.Web.Models
{
    public class AddressModel
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}