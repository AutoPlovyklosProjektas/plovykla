using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plovykla.Models
{
    public class Kategorija
    {
        [Key]
        public int kategorijosId { get; set; }
        public string kategorijosPavadinimas { get; set; }

        //[ForeignKey("kategorijosId")]
        public virtual ICollection<Vartotojai> Vartotojai { get; set; }
    }
}   