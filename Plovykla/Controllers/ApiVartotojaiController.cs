using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plovykla.Models;

namespace Plovykla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiVartotojaiController : ControllerBase
    {
        private readonly SistemosCtx _context;

        public ApiVartotojaiController(SistemosCtx context)
        {
            _context = context;
        }

        [HttpPost("GautiVartotoja")]
        public IActionResult GautiVartotoja([FromBody] Vartotojai vartotojai)
        {
            var vartotojas = (from s in _context.Vartotojais
                              where s.username == vartotojai.username
                              select s).FirstOrDefault<Vartotojai>();

            if (vartotojas == null)
            {
                return NotFound();
            }

            return Ok(vartotojas);
        }


        [HttpPost("PostVartotojai")]
        public IActionResult PostVartotojai([FromBody] Vartotojai vartotojai)
        {
            Registracijai reg = new Registracijai();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var ArNeuzimtasUserName = (from s in _context.Vartotojais
                                       where s.username == vartotojai.username
                                       select s).FirstOrDefault<Vartotojai>();

            var ArNeuzimtasEmail = (from s in _context.Vartotojais
                                    where s.email == vartotojai.email
                                    select s).FirstOrDefault<Vartotojai>();

            if (ArNeuzimtasUserName == null && ArNeuzimtasEmail == null)
            {
                vartotojai.kategorijosId = 3;
                _context.Vartotojais.Add(vartotojai);
                _context.SaveChanges();
                reg.busena = "Registracija sekminga!";
            }
            else
            {
                if (ArNeuzimtasUserName != null && ArNeuzimtasEmail != null)
                {
                    reg.busena = "Vartotojo vardas ir elektroninis pastas uzimtas!";

                }
                else if (ArNeuzimtasEmail != null)
                {
                    reg.busena = "Elektroninis pastas uzimtas!";
                }
                else
                {
                    reg.busena = "Vartotojo vardas uzimtas!";
                }
            }
            return Ok(reg);
        }

        [HttpPost("EditVartotojai")]
        public IActionResult EditVartotojai([FromBody] VartotojaiEdit vartotojai)
        {
            var vartotojas = (from s in _context.Vartotojais
                              where s.username == vartotojai.username
                              select s).FirstOrDefault<Vartotojai>();
            if (vartotojas == null)
            {
                return BadRequest(ModelState);
            }
            if (vartotojai.vardas != null)
            {
                vartotojas.vardas = vartotojai.vardas;
            }
            if (vartotojai.pavarde != null)
            {
                vartotojas.pavarde = vartotojai.pavarde;
            }
            if (vartotojai.email != null)
            {
                vartotojas.email = vartotojai.email;
            }

            if (vartotojai.password != null && vartotojai.newPassword != null)
            {
                if (vartotojas.password.Equals(vartotojai.password))
                {
                    vartotojas.password = vartotojai.newPassword;
                }
                else
                {
                    vartotojai.busena = "Senasis slaptazodis neteisingas!";
                    return Ok(vartotojai);
                }
            }

            _context.Entry(vartotojas).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            vartotojai.busena = "Pakeista sekmingai!";
            return Ok(vartotojai);
        }


        private bool VartotojaiExists(int id)
        {
            return _context.Vartotojais.Any(e => e.vartotojoId == id);
        }
    }
}