using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETB310_LandlordV2.Models
{
    public class ServiceCasePostViewModel
    {
        public string CaseMessage { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public bool Private { get; set; }

    }
}