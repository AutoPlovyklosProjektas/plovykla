using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plovykla.Models
{
    public class Trukumai
    {
        [Key]
        public int trukumoId { get; set; }
        public int medziagosId { get; set; }

        //[ForeignKey("medziagosId")]
        public virtual Medziagos Medziagos { get; set; }
    }
}