using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbacusApp3.Models
{
    public class Lokalizacja
    {

        public int LokalizacjaId { get; set; }
        [Display(Name = "Nazwa")]
        public string NazwaLok { get; set; }
        [Display(Name = "Ulica")]
        public string Ulica { get; set; }
        [Display(Name = "Numer domu")]
        public string NrDomu { get; set; }
        [Display(Name = "Numer lokalu")]
        public string NrLokalu { get; set; }
        [Display(Name = "Kod pocztowy")]
        [RegularExpression("[0-9]{2}-[0-9]{3}", ErrorMessage = "Format kodu pocztowego to: xx-xxx.")]
        public string KodPocztowy { get; set; }
        [Display(Name = "Miejscowość")]
        public string Miejscowosc { get; set; }
    }
}
