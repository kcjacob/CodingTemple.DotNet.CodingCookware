using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingTemple.CodingCookware.Web.Models
{
    public class CheckoutModel
    {
        public string ContactEmail { get; set; }

        public string ContactPhone { get; set; }

        public string ShippingAddressLine1 { get; set; }
        public string ShippingAddressLine2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set; }

        public ICollection<Address> SavedAddresses { get; set; }

        public Basket Basket { get; set; }

        public string CreditCardNumber { get; set; }
        public int CreditCardExpirationMonth { get; set; }
        public int CreditCardExpirationYear { get; set; }
        public string CreditCardVerificationValue { get; set; }
        public string CreditCardNameOnCard { get; set; }
    }
}