using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plovykla.Models
{
    public class UzsakymasByKlientas
    {
        public int klientoId { get; set; }
        public int uzsakymoId { get; set; }
        public int paslaugosId { get; set; }
        public int busenosId { get; set; }
        public double uzsakymoKaina { get; set; }
        public string busenosPavadinimas { get; set; }
        public string paslaugosPavadinimas { get; set; }
    }
}