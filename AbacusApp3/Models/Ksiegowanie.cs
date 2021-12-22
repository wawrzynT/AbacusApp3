using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AbacusApp3.Models
{
    
    public class Ksiegowanie
    {
            
        public int KsiegowanieId { get; set; }

        [Display(Name = "Lokalizacja")] 
        public int LokalizacjaId { get; set; }
        public Lokalizacja Lokalizacja { get; set; }

        [Display(Name = "Konto")] 
        public int KontoId { get; set; }
        public Konto Konto { get; set; }

        [Display(Name = "Termin płatności")]
        [DataType(DataType.Date)]
        public DateTime TerminPlatnosci { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name ="Kwota do zapłaty")] 

        public double KwotaWn { get; set; }
        [Display(Name ="Data płatności")]
        [DataType(DataType.Date)]

        public DateTime? KwotaWplaty { get; set; }
        [Display(Name="Kwota wpłaty")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]

        public double? KwotaMa { get; set; }
    }
}
