using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingTemple.CodingCookware.Web.Models
{ 
    public class CheckoutModel : IValidatableObject
    {
        public CheckoutModel()
        {
            this.BillingAddress = new AddressModel();
            this.ShippingAddress = new AddressModel();
        }

        public AddressModel BillingAddress { get; set; }
        public AddressModel ShippingAddress { get; set; }
        public string ShippingToLine { get; set; }

        //[Required]
        [Phone]
        [Display(Name ="Phone Number")]
        public string ContactPhone { get; set; }

        //[Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [CreditCard]
        public string CreditCardNumber { get; set; }

        [MinLength(3)]
        [MaxLength(4)]
        public string CreditCardVerificationValue { get; set; }

        public int? CreditCardExpirationMonth { get; set; }
        public int? CreditCardExpirationYear { get; set; }
        public string CreditCardName { get; set; }

        //Custom validation lets me add error messages in more complex scenarios that built-in attributes don't cover
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(ContactEmail) && string.IsNullOrEmpty(ContactPhone))
            {
                yield return new ValidationResult("Email or Phone Number must be provided", new string[]{"ContactPhone", "ContactEmail"});
            }
        }
    }
}