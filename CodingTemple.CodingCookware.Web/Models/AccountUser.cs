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
    
    public partial class AccountUser
    {
        public int UserID { get; set; }
        public int AccountID { get; set; }
        public bool PrimaryUser { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual User User { get; set; }
    }
}
