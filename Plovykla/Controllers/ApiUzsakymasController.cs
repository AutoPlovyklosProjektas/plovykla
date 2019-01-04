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
    public class ApiUzsakymasController : ControllerBase
    {
        private readonly SistemosCtx _context;

        public ApiUzsakymasController(SistemosCtx context)
        {
            _context = context;
        }

        // GET: api/ApiUzsakymas
        [HttpGet("GetUzsakymas")]
        public IEnumerable<Uzsakymas> GetUzsakymas()
        {
            return _context.Uzsakymas;
        }

        // GET: api/ApiUzsakymas/5
        [HttpPost("UzsakymasByKlientoId")]
        public IActionResult UzsakymasByKlientoId([FromBody] UzsakymasByKlientas uzsakymasByKlientas)
        {
            var uzsakymas = (from s in _context.Uzsakymas
                             where s.klientoId == uzsakymasByKlientas.klientoId && s.busenosId != 4
                             select s).FirstOrDefault<Uzsakymas>();

            if (uzsakymas == null)
            {
                return NotFound();
            }
            var paslauga = _context.Paslaugas.Find(uzsakymas.paslaugosId);
            var busena = _context.Busenos.Find(uzsakymas.busenosId);
            uzsakymasByKlientas.paslaugosId = uzsakymas.paslaugosId;
            uzsakymasByKlientas.uzsakymoId = uzsakymas.uzsakymoId;
            uzsakymasByKlientas.uzsakymoKaina = uzsakymas.uzsakymoKaina;
            uzsakymasByKlientas.paslaugosPavadinimas = paslauga.paslaugosPavadinimas;
            uzsakymasByKlientas.busenosPavadinimas = busena.busena;
            uzsakymasByKlientas.busenosId = busena.busenosId;
            return Ok(uzsakymasByKlientas);
        }

        // PUT: api/ApiUzsakymas/5
        [HttpPut("PutUzsakymas/{id}")]
        public async Task<IActionResult> PutUzsakymas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Uzsakymas uzsakymas = _context.Uzsakymas.Find(id);

            if (id != uzsakymas.uzsakymoId)
            {
                return BadRequest();
            }
            uzsakymas.busenosId = 4;
            _context.Entry(uzsakymas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UzsakymasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiUzsakymas
        [HttpPost("PostUzsakymas")]
        public async Task<IActionResult> PostUzsakymas([FromBody] Uzsakymas uzsakymas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            uzsakymas.busenosId = 1;
            _context.Uzsakymas.Add(uzsakymas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUzsakymas", new { id = uzsakymas.uzsakymoId }, uzsakymas);
        }



        private bool UzsakymasExists(int id)
        {
            return _context.Uzsakymas.Any(e => e.uzsakymoId == id);
        }
    }
}