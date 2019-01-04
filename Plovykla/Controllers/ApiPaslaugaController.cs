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
    public class ApiPaslaugaController : ControllerBase
    {
        private readonly SistemosCtx _context;

        public ApiPaslaugaController(SistemosCtx context)
        {
            _context = context;
        }

        // GET: api/ApiPaslauga
        [HttpGet("GetPaslaugas")]
        public IEnumerable<Paslauga> GetPaslaugas()
        {
            return _context.Paslaugas;
        }

        // GET: api/ApiPaslauga/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaslauga([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paslauga = await _context.Paslaugas.FindAsync(id);

            if (paslauga == null)
            {
                return NotFound();
            }

            return Ok(paslauga);
        }



        private bool PaslaugaExists(int id)
        {
            return _context.Paslaugas.Any(e => e.paslaugosId == id);
        }
    }
}