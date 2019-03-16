using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETB310_LandlordV2.Models
{
    public class ServiceCaseViewModel
    {
        public int CaseNr { get; set; } // sätts automatiskt av webbservicen vid sparning 

        public DateTime Date { get; set; } // sätts automatiskt av webbservicen vid sparning 

        public int FlatNr { get; set; } // optional 

        public string Name { get; set; } // optional 

        public string ContactEmail { get; set; } // obligatory 

        public string NewPostName { get; set; } // obligatory 
        public bool NewPostPrivate { get; set; } // obligatory 

        [Required(ErrorMessage = "Du m�ste beskriva ditt �rende.")]
        [StringLength(2000, ErrorMessage = "Beskrivningen f�r inte vara l�ngre �n 2000 tecken.", MinimumLength = 2)]
        public string NewPostMessage{ get; set; } // obligatory 
        public int TryCount { get; set; } 

        public IEnumerable<ServiceCasePostViewModel> Posts { get; set; }
        public ServiceCaseViewModel()
        {
            Posts = new List<ServiceCasePostViewModel>();
        }
    }
}