using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETB310_LandlordV2.Models
{
    public class ServiceCaseViewModel
    {
        public int CaseNr { get; set; } // s�tts automatiskt av webbservicen vid sparning 

        public DateTime Date { get; set; } // s�tts automatiskt av webbservicen vid sparning 

        [Required(ErrorMessage = "Du m�ste ange ett l�genhetsnumer.")]
        [Range(1000, 9999, ErrorMessage = "L�genhetsnumret m�ste var fyra siffror.")]
        public int FlatNr { get; set; } 

        [Required(ErrorMessage = "Du m�ste ange ett namn.")]
        [StringLength(30, ErrorMessage = "Namn m�ste vara minst 2 tecken och inte l�ngre �n 30 tecken", MinimumLength = 2)]
        public string Name { get; set; } 

        [Required(ErrorMessage = "Du m�ste skriva en emailadres.")]
        [StringLength(40, ErrorMessage = "Epostadressen m�ste vara minst 6 tecken och inte l�ngre �n 40 tecken.", MinimumLength = 6)]
        [RegularExpression(@"[\w\.-_]+@([\w\.-_]+\.)+[a-z]+", ErrorMessage = "Detta �r inte en giltig e-postadress")]
        public string ContactEmail { get; set; } 

        public string NewPostName { get; set; } 
        public bool NewPostPrivate { get; set; } 

        [Required(ErrorMessage = "Du m�ste skriva n�got.")]
        [StringLength(2000, ErrorMessage = "Beskrivningen f�r inte vara l�ngre �n 2000 tecken.")]
        public string NewPostMessage{ get; set; } 
        public int TryCount { get; set; } 

        public IEnumerable<ServiceCasePostViewModel> Posts { get; set; }
        public ServiceCaseViewModel()
        {
            Posts = new List<ServiceCasePostViewModel>();
        }
    }
}