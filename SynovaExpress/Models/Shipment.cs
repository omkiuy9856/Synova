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
    
    public partial class Shipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipment()
        {
            this.DistributeCenters = new HashSet<DistributeCenter>();
            this.Status = new HashSet<Status>();
        }
    
        public int ShipmentNo { get; set; }
        public int CustomerID { get; set; }
        public string receiver_name { get; set; }
        public string receiver_address { get; set; }
        public int receiver_zipcode { get; set; }
        public int receiver_tel { get; set; }
        public int quantity { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<System.DateTime> shipment_date { get; set; }
        public Nullable<System.DateTime> booking_date { get; set; }
        public Nullable<int> weight { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DistributeCenter> DistributeCenters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Status> Status { get; set; }
    }
}