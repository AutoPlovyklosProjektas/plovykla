using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plovykla.Models
{
    public class Medziagos
    {
        [Key]
        public int medziagosId { get; set; }
        public string medziaga { get; set; }

        //[ForeignKey("medziagosId")]
        public virtual ICollection<Trukumai> Trukumai { get; set; }
    }
}