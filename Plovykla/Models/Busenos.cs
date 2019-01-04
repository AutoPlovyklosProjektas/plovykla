using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plovykla.Models
{
    public class Busenos
    {
        [Key]
        public int busenosId { get; set; }
        public string busena { get; set; }

        //[ForeignKey("busenosId")]
        public virtual ICollection<Uzsakymas> Uzsakymas { get; set; }
    }
}