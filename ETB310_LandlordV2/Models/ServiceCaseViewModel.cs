using System;
using System.Collections.Generic;

namespace ETB310_LandlordV2.Models
{
    public class ServiceCaseViewModel
    {
        public int CaseNr { get; set; } // sätts automatiskt av webbservicen vid sparning 

        public DateTime Date { get; set; } // sätts automatiskt av webbservicen vid sparning 

        public int FlatNr { get; set; } // optional 

        public string Name { get; set; } // optional 

        public string ContactEmail { get; set; } // obligatory 

        public IEnumerable<ServiceCasePostViewModel> Posts { get; set; }
    }
}