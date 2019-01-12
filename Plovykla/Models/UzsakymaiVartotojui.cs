using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plovykla.Models
{
    public class UzsakymaiVartotojui
    {
        public string paslaugosPavadinimas { get; set; }
        public DateTime? uzsakymo_Data { get; set; }
        public double? uzsakymoKaina { get; set; }
    }
}