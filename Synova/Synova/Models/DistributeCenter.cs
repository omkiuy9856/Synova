using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Synova.Models
{
    public partial class DistributeCenter
    {
        public int Id { get; set; }
        [DisplayName("Shipment No.")]
        public int ShipmentID { get; set; }
        [DisplayName("User")]
        public string user_name { get; set; }
        [DisplayName("Driver")]
        public string driver_name { get; set; }
    

        public virtual Driver Driver { get; set; }
        public virtual User User { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}