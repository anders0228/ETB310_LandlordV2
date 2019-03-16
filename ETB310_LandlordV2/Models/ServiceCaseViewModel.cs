using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETB310_LandlordV2.Models
{
    public class ServiceCaseViewModel
    {
        public int CaseNr { get; set; } // sÃ¤tts automatiskt av webbservicen vid sparning 

        public DateTime Date { get; set; } // sÃ¤tts automatiskt av webbservicen vid sparning 

        public int FlatNr { get; set; } // optional 

        public string Name { get; set; } // optional 

        public string ContactEmail { get; set; } // obligatory 

        public string NewPostName { get; set; } // obligatory 
        public bool NewPostPrivate { get; set; } // obligatory 

        [Required(ErrorMessage = "Du måste beskriva ditt ärende.")]
        [StringLength(2000, ErrorMessage = "Beskrivningen får inte vara längre än 2000 tecken.", MinimumLength = 2)]
        public string NewPostMessage{ get; set; } // obligatory 
        public int TryCount { get; set; } 

        public IEnumerable<ServiceCasePostViewModel> Posts { get; set; }
        public ServiceCaseViewModel()
        {
            Posts = new List<ServiceCasePostViewModel>();
        }
    }
}