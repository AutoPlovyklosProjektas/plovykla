using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Plovykla.Models;

namespace Plovykla.Controllers
{
    public class AnalizeController : Controller
    {
        private readonly SistemosCtx _context;
        public AnalizeController(SistemosCtx context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["darbuotojai"] = new SelectList(_context.Vartotojais.Where(s => s.kategorijosId == 2), "vartotojoId", "vardas");
            return View();
        }
        [HttpPost,ActionName("Vartotojo_Analize")]
        [ValidateAntiForgeryToken]
        public IActionResult Vartotojo_Analize([Bind("data_nuo,data_iki,vartotojoId")]Analizei anal)
        {
            Vartotojai vart = _context.Vartotojais.Find(anal.vartotojoId);

            var uzs = (from s in _context.Uzsakymas
                       join e in _context.Paslaugas on s.paslaugosId equals e.paslaugosId
                       where s.uzsakymo_Data >= anal.data_nuo && s.uzsakymo_Data < anal.data_iki && s.darbuotojoId == anal.vartotojoId
                       select new
                       {
                           e.paslaugosPavadinimas,
                           s.uzsakymo_Data,
                           s.uzsakymoKaina
                       }).ToList();


            List<UzsakymaiVartotojui> uzsakymai = new List<UzsakymaiVartotojui>();

            foreach (var uzsakymas in uzs)
            {
                uzsakymai.Add(new UzsakymaiVartotojui
                {
                    paslaugosPavadinimas = uzsakymas.paslaugosPavadinimas,
                    uzsakymoKaina = uzsakymas.uzsakymoKaina,
                    uzsakymo_Data = uzsakymas.uzsakymo_Data
                });
            }

            var baudosVartotojui = (from s in _context.Baudos
                                    join e in _context.Uzsakymas on s.uzsakymoId equals e.uzsakymoId
                                    join t in _context.Paslaugas on e.paslaugosId equals t.paslaugosId
                                    where s.data >= anal.data_nuo && s.data < anal.data_iki && s.vartotojoId == anal.vartotojoId
                                    select new
                                    {
                                        paslauga = t.paslaugosPavadinimas,
                                        aprasymas = s.baudosAprasymas,
                                        b_data = s.data,
                                        b_nuostolis = s.nuostolis
                                    }).ToList();

            List<BaudaVartotojui> bauda = new List<BaudaVartotojui>();
            foreach (var v in baudosVartotojui)
            {
                bauda.Add(new BaudaVartotojui
                {
                    paslauga = v.paslauga,
                    aprasymas = v.aprasymas,
                    b_data = v.b_data,
                    b_nuostolis = v.b_nuostolis
                });
            }
            //Apsiskaiciuoju kokia bendra alga
            double pirmineSuma = uzsakymai.Sum(x => x.uzsakymoKaina);
            double baudosSuma = bauda.Sum(x => x.b_nuostolis);
            double bendraAlga = pirmineSuma - baudosSuma;

            //Darau, kad galeciau i views persidet duomenis
            ViewData["alga"] = bendraAlga;
            ViewData["VartotojoObj"] = vart;
            ViewData["uzsakymai"] = uzsakymai;
            ViewData["baudos"] = bauda;



            return View();
        }
    }
}