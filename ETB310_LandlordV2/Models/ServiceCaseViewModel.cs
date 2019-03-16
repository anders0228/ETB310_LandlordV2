using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETB310_LandlordV2.Models
{
    public class ServiceCaseViewModel
    {
        public int CaseNr { get; set; } // sätts automatiskt av webbservicen vid sparning 

        public DateTime Date { get; set; } // sätts automatiskt av webbservicen vid sparning 

        [Required(ErrorMessage = "Du måste ange ett lägenhetsnumer.")]
        [Range(1000, 9999, ErrorMessage = "Lägenhetsnumret måste var fyra siffror.")]
        public int FlatNr { get; set; } 

        [Required(ErrorMessage = "Du måste ange ett namn.")]
        [StringLength(30, ErrorMessage = "Namn måste vara minst 2 tecken och inte längre än 30 tecken", MinimumLength = 2)]
        public string Name { get; set; } 

        [Required(ErrorMessage = "Du måste skriva en emailadres.")]
        [StringLength(40, ErrorMessage = "Epostadressen måste vara minst 6 tecken och inte längre än 40 tecken.", MinimumLength = 6)]
        [RegularExpression(@"[\w\.-_]+@([\w\.-_]+\.)+[a-z]+", ErrorMessage = "Detta är inte en giltig e-postadress")]
        public string ContactEmail { get; set; } 

        public string NewPostName { get; set; } 
        public bool NewPostPrivate { get; set; } 

        [Required(ErrorMessage = "Du måste skriva något.")]
        [StringLength(2000, ErrorMessage = "Beskrivningen får inte vara längre än 2000 tecken.")]
        public string NewPostMessage{ get; set; } 
        public int TryCount { get; set; } 

        public IEnumerable<ServiceCasePostViewModel> Posts { get; set; }
        public ServiceCaseViewModel()
        {
            Posts = new List<ServiceCasePostViewModel>();
        }
    }
}