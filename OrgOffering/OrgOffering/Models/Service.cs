using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OrgOffering.Models
{
    public partial class Service
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
