//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SynovaExpress.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Status
    {
        public int StatusId { get; set; }
        public string status_name { get; set; }
        public int ShipmentID { get; set; }
        public Nullable<System.TimeSpan> time { get; set; }
    
        public virtual Shipment Shipment { get; set; }
    }
}
