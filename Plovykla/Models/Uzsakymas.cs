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
        [Required(ErrorMessage = "Nepasirinkta data.")]
        [DateTimeRange]
        public DateTime? uzsakymo_Data { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Laukas '{0}' neužpildytas.")]
        [Range(1, 999.99, ErrorMessage = "Įrašykite kainą nuo 1.00 iki 999.99")]
        [Display(Name = "Kaina")]
        public double? uzsakymoKaina { get; set; }
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

    public class DateTimeRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                value = DateTime.Now.AddYears(-9999);
            }
            else {
                value = (DateTime)value;
            }

            int lessThanMax = DateTime.Now.AddYears(9).CompareTo(value);
            int moreThanMin = DateTime.Now.AddDays(-1).CompareTo(value);

            if (lessThanMax >= 0 && moreThanMin <= 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Netinkama data.");
            }
        }
    }
}