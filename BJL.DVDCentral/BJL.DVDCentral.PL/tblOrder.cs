//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BJL.DVDCentral.PL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string PaymentReceipt { get; set; }
        public System.DateTime ShipDate { get; set; }
        public int UserId { get; set; }
    }
}
