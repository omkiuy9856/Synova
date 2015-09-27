using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Synova.Models
{
    public partial class Status
    {
        public int StatusId { get; set; }
        [DisplayName("Status")]
        public string status_name { get; set; }
        [DisplayName("Shipment No.")]
        public int ShipmentID { get; set; }
        [DisplayName("Updated Time")]
        public Nullable<System.TimeSpan> time { get; set; }

        public virtual Shipment Shipment { get; set; }
    }
}