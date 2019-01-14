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
    public class LoginController : Controller
    {

        private readonly SistemosCtx _context;

        public LoginController(SistemosCtx context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            catch
            {
                ViewBag.Error = "";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("username,password")]string username,string password)
        {
            if(username != null && password != null)
            {
                var vartotojas = (from s in _context.Vartotojais
                                  where s.username == username && s.password == password
                                  select s).FirstOrDefault<Vartotojai>();
                if(vartotojas != null)
                {
                    if (vartotojas.kategorijosId == 1)
                    {

                        var str = JsonConvert.SerializeObject(vartotojas);

                        HttpContext.Session.SetString("vartotojas",str);
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (vartotojas.kategorijosId == 2)
                    {
                        var str = JsonConvert.SerializeObject(vartotojas);
                        HttpContext.Session.SetString("vartotojas", str);
                        return RedirectToAction("Index", "Darbuotojas");
                    }
                    else
                    {
                        TempData["Error"] = "Klientai gali prisijungti tik per appsa!";
                        return RedirectToAction("Index", "Login");
                    }
                }
                else
                {
                    TempData["Error"] = "Neteisingas slaptazodis ar prisijungimo vardas!";
                    return RedirectToAction("Index", "Login");
                }
                
            }
            else
            {
                TempData["Error"] = "Slaptazodis ar passwordas neivestas!";
                return RedirectToAction("Index", "Login");
            }
           // return RedirectToAction("Index", "Vartotojais");
        }

        #region atsijungimas

        public ActionResult LogOut()
        {
            //Session.Abandon();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        #endregion
    }

}