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
        [Required(ErrorMessage = "Laukas '{0}' neužpildytas.")]
        [Range(1, 999.99, ErrorMessage = "Įrašykite kainą nuo 1.00 iki 999.99")]
        [Display(Name = "Kaina")]
        public double? paslaugosKaina { get; set; }
        [Required(ErrorMessage = "Laukas '{0}' neužpildytas.")]
        [Display(Name = "Pavadinimas")]
        public string paslaugosPavadinimas { get; set; }
        [Required(ErrorMessage = "Laukas '{0}' neužpildytas.")]
        [Display(Name = "Aprašymas")]
        public string paslaugosAprasymas { get; set; }

        //[ForeignKey("paslaugosId")]
        public virtual ICollection<Uzsakymas> Uzsakymas { get; set; }
        public virtual ICollection<Atsiliepimai> Atsiliepimas { get; set; }
    }
}