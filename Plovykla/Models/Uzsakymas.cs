using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plovykla.Models
{
    public class Uzsakymas
    {
        [Key]
        public int uzsakymoId { get; set; }
        public DateTime uzsakymo_Data { get; set; }
        public double uzsakymoKaina { get; set; }
        public int paslaugosId { get; set; }
        [ForeignKey("Vartotojai")]
        public int? darbuotojoId { get; set; }

        [ForeignKey("Klientai")]
        public int? klientoId { get; set; }
        public int busenosId { get; set; }

        //[ForeignKey("vartotojoId")]
        //Darbuotojas
        public virtual Vartotojai Vartotojai { get; set; }
        //Klientas
        public virtual Vartotojai Klientai { get; set; }
        //[ForeignKey("paslaugosId")]
        public virtual Paslauga Paslauga { get; set; }
        //[ForeignKey("busenosId")]
        public virtual Busenos Busenos { get; set; }

        //[ForeignKey("uzsakymoId")]
        public virtual ICollection<Baudos> Baudos { get; set; }
    }
}