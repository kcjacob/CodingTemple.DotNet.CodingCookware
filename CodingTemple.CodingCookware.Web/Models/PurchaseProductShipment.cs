//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodingTemple.CodingCookware.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseProductShipment
    {
        public int ShipmentID { get; set; }
        public int PurchaseProductID { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
    
        public virtual PurchaseProduct PurchaseProduct { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
