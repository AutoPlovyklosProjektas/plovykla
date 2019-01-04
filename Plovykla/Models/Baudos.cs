using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plovykla.Models
{
    public class Baudos
    {
        [Key]
        public int baudosId { get; set; }
        public string baudosAprasymas { get; set; }
        public double nuostolis { get; set; }
        public DateTime data { get; set; }
        public int vartotojoId { get; set; }
        public int uzsakymoId { get; set; }

        //[ForeignKey("vartotojoId")]
        public virtual Vartotojai Vartotojai { get; set; }
        //[ForeignKey("uzsakymoId")]
        public virtual Uzsakymas Uzsakymas { get; set; }
    }
} 