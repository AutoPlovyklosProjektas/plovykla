using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Plovykla.Models;

namespace Plovykla.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            Vartotojai vartotojas = getVart();
            if(vartotojas != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult pas_v()
        {
            Vartotojai vartotojas = getVart();
            if (vartotojas != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult darb_v()
        {
            Vartotojai vartotojas = getVart();
            if (vartotojas != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }




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