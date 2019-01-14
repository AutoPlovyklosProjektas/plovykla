using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Plovykla.Models;

namespace Plovykla.Controllers
{
    public class DarbuotojasController : Controller
    {
        private readonly SistemosCtx _context;

        public DarbuotojasController(SistemosCtx context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Vartotojai vartotojas = getVart();
            string swx = "Sveiki " + vartotojas.vardas + " " + vartotojas.pavarde;
            ViewData["pasisveikinimas"] = swx;
            return View();
        }


        #region priskirti uzsakymai
        public ActionResult Uzsakymai()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Priskirti_Uzsakymai([Bind("data_nuo,data_iki")] Analizei anal )
        {
            Vartotojai vartotojas = getVart();
            Vartotojai vart = _context.Vartotojais.Find(vartotojas.vartotojoId);

            var uzs = (from s in _context.Uzsakymas
                       join e in _context.Paslaugas on s.paslaugosId equals e.paslaugosId
                       where s.uzsakymo_Data >= anal.data_nuo && s.uzsakymo_Data < anal.data_iki && s.darbuotojoId == vartotojas.vartotojoId
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
            ViewData["uzsakymai"] = uzsakymai;
            return View();
        }
        #endregion

        #region analize
        public ActionResult Analize()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Darbuotojo_Analize([Bind("data_nuo,data_iki")] Analizei anal)
        {
            Vartotojai vartotojas = getVart();
            Vartotojai vart = _context.Vartotojais.Find(vartotojas.vartotojoId);


            var uzs = (from s in _context.Uzsakymas
                       join e in _context.Paslaugas on s.paslaugosId equals e.paslaugosId
                       where s.uzsakymo_Data >= anal.data_nuo && s.uzsakymo_Data < anal.data_iki && s.darbuotojoId == vartotojas.vartotojoId
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
                                    where s.data >= anal.data_nuo && s.data < anal.data_iki && s.vartotojoId == vartotojas.vartotojoId
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
            double? pirmineSuma = uzsakymai.Sum(x => x.uzsakymoKaina);
            double? baudosSuma = bauda.Sum(x => x.b_nuostolis);
            double? bendraAlga = pirmineSuma - baudosSuma;

            //Darau, kad galeciau i views persidet duomenis
            ViewBag.alga = bendraAlga;
            ViewBag.VartotojoObj = vart;
            ViewBag.uzsakymai = uzsakymai;
            ViewBag.baudos = bauda;
            return View();
        }
        #endregion

        #region info keitimas
        public ActionResult InfoKeitimas(string success)
        {
            Vartotojai vartotojai = getVart();
            ViewBag.success = success;
            return View(vartotojai);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InfoKeitimas([Bind("vartotojoId,vardas,pavarde,email")] Vartotojai vartotojai)
        {
            Vartotojai vart = getVart();
            vart.vardas = vartotojai.vardas;
            vart.pavarde = vartotojai.pavarde;
            vart.email = vartotojai.email;

            if(ModelState.ErrorCount <= 2)
            {
                ModelState.Remove("username");
                ModelState.Remove("password");
            }

            if (ModelState.IsValid)
            {
                vartotojai.kategorijosId = 2;
                _context.Update(vart);
                 _context.SaveChanges();
                return RedirectToAction(nameof(InfoKeitimas), new { success = "Informacijos pakeitimas sėkmingas." });
            }
            
            return View(vartotojai);
        }
        #endregion


        #region trukumai
        public ActionResult Trukumu_Pridejimas()
        {
            ViewBag.medziagosId = new SelectList(_context.Medziagos, "medziagosId", "medziaga");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Trukumu_Pridejimas_fnc([Bind("trukumoId,medziagosId")] Trukumai trukumai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trukumai);
                _context.SaveChanges();

            }
            return RedirectToAction("Trukumu_Pridejimas", "Darbuotojas");
        }


        #endregion

        public Vartotojai getVart()
        {
            try
            {
                var str = HttpContext.Session.GetString("vartotojas");
                var vartotojas = JsonConvert.DeserializeObject<Vartotojai>(str);
                return vartotojas;
            }
            catch
            {
                return null;
            }
        }
    }
}