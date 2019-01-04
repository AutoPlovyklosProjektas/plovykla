using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plovykla.Models;

namespace Plovykla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiLoginController : ControllerBase
    {
        private readonly SistemosCtx _context;

        public ApiLoginController(SistemosCtx context)
        {
            _context = context;
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Prisijungimui prisijungimui)
        {
            var vartotojas = (from s in _context.Vartotojais
                              where s.username == prisijungimui.username && s.password == prisijungimui.password
                              select s).FirstOrDefault<Vartotojai>();
            if (vartotojas != null)
            {
                prisijungimui.arGalima = 1;
                return Ok(prisijungimui);
            }
            else
            {
                prisijungimui.arGalima = 0;
                return Ok(prisijungimui);
            }
        }
    }
}