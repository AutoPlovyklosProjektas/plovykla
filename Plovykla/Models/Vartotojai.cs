using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plovykla.Models
{
    public class Vartotojai
    {
        [Key]
        public int vartotojoId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public string email { get; set; }
        public int kategorijosId { get; set; }

        //[ForeignKey("kategorijosId")]
        public virtual Kategorija Kategorija { get; set; }
        //[ForeignKey("vartotojoId")]
        public virtual ICollection<Baudos> Baudos { get; set; }
        //[ForeignKey("uzsakymoId")]
        [InverseProperty("Vartotojai")]
        public virtual ICollection<Uzsakymas> Uzsakymas { get; set; }

        public virtual ICollection<Atsiliepimai> Atsiliepimai { get; set; }

        [InverseProperty("Klientai")]
        public virtual ICollection<Uzsakymas> Klientai { get; set; }
        public Vartotojai() { }

        public Vartotojai(string username, string password, string vardas, string pavarde, string email, int kategorijosId)
        {
            this.username = username;
            this.password = password;
            this.vardas = vardas;
            this.pavarde = pavarde;
            this.email = email;
            this.kategorijosId = kategorijosId;
        }

    }
}