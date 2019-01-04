using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plovykla.Models
{
    public class Atsiliepimai
    {
        [Key]
        public int atsiliepimoId { get; set; }
        public string atsiliepimas { get; set; }
        public int paslaugosId { get; set; }
        public int vartotojoId { get; set; }


        public virtual Paslauga Paslauga { get; set; }
        public virtual Vartotojai Vartotojai { get; set; }
    }
}