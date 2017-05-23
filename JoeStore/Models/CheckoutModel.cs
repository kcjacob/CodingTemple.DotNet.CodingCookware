using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoeStore.Models
{
    public class CheckoutModel
    {
        public CheckoutModel()
        {
            this.BillingAddress = new AddressModel();
            this.ShippingAddress = new AddressModel();
        }

        public AddressModel BillingAddress { get; set; }
        public AddressModel ShippingAddress { get; set; }
        public string ShippingToLine { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        public string CreditCardNumber { get; set; }
        public string CreditCardVerificationValue { get; set; }
        public int? CreditCardExpirationMonth { get; set; }
        public int? CreditCardExpirationYear { get; set; }
        public string CreditCardName { get; set; }

    }
}