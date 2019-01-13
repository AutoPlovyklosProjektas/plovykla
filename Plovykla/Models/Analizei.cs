using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plovykla.Models
{
    public class Analizei
    {
        [Required(ErrorMessage = "Nepasirinkta data.")]
        [DateTimeRange]
        public DateTime data_nuo { get; set; }
        [Required(ErrorMessage = "Nepasirinkta data.")]
        [DateTimeRange]
        public DateTime data_iki { get; set; }
        public int vartotojoId { get; set; }
    }
}
