using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbacusApp3.Models
{
    public class Osoba
    {
        public int OsobaId { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Pesel { get; set; }
        public string DokumentTozsamosci { get; set; }
        public int LokalizacjaId { get; set; }
        public Lokalizacja Lokalizacja { get; set; }
    }
}
