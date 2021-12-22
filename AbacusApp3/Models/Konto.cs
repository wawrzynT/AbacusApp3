using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbacusApp3.Models
{
    public class Konto
    {
        public int KontoId { get; set; }
        [Display(Name = "Nazwa konta")]
        public string NazwaKonta { get; set; }
        public virtual ICollection<Konto> Konta { get; set; }

    }
}
