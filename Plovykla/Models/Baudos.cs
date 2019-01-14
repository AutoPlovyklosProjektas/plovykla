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
        [Required(ErrorMessage = "Laukas '{0}' neužpildytas.")]
        [Display(Name = "Aprašymas")]
        public string baudosAprasymas { get; set; }
        [Required(ErrorMessage = "Laukas '{0}' neužpildytas.")]
        [Display(Name = "Nuostolis")]
        [Range(1, 999999.99, ErrorMessage = "Įrašykite nuostolių kainą nuo 1.00 iki 999999.99")]
        public double? nuostolis { get; set; }
        [Required(ErrorMessage = "Nepasirinkta data.")]
        [DateTimeRange]
        [Display(Name = "Data")]
        public DateTime? data { get; set; }
        [Display(Name = "Darbuotojas")]
        public int vartotojoId { get; set; }
        [Display(Name = "Užsakymo ID")]
        public int uzsakymoId { get; set; }

        //[ForeignKey("vartotojoId")]
        public virtual Vartotojai Vartotojai { get; set; }
        //[ForeignKey("uzsakymoId")]
        public virtual Uzsakymas Uzsakymas { get; set; }
    }
} 