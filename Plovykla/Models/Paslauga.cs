using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plovykla.Models
{
    public class Paslauga
    {
        [Key]
        public int paslaugosId { get; set; }
        public double paslaugosKaina { get; set; }
        public string paslaugosPavadinimas { get; set; }
        public string paslaugosAprasymas { get; set; }

        //[ForeignKey("paslaugosId")]
        public virtual ICollection<Uzsakymas> Uzsakymas { get; set; }
        public virtual ICollection<Atsiliepimai> Atsiliepimas { get; set; }
    }
}