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
    public class ApiAtsiliepimaiController : ControllerBase
    {
        private readonly SistemosCtx _context;

        public ApiAtsiliepimaiController(SistemosCtx context)
        {
            _context = context;
        }

        // GET: api/ApiAtsiliepimai
        [HttpGet]
        public IEnumerable<Atsiliepimai> GetAtsiliepimais()
        {
            return _context.Atsiliepimais;
        }

        [HttpGet("GetAtsiliepimaiByPaslauga/{id}")]
        public IQueryable<Atsiliepimai> GetAtsiliepimaiByPaslauga([FromRoute] int id)
        {
            var atsiliepimai = (from s in _context.Atsiliepimais
                                where s.paslaugosId == id
                                select s);
            return atsiliepimai;
        }

        // GET: api/ApiAtsiliepimai/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAtsiliepimai([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var atsiliepimai = await _context.Atsiliepimais.FindAsync(id);

            if (atsiliepimai == null)
            {
                return NotFound();
            }

            return Ok(atsiliepimai);
        }



        // POST: api/ApiAtsiliepimai
        [HttpPost("PostAtsiliepimai")]
        public async Task<IActionResult> PostAtsiliepimai([FromBody] Atsiliepimai atsiliepimai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Atsiliepimais.Add(atsiliepimai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtsiliepimai", new { id = atsiliepimai.atsiliepimoId }, atsiliepimai);
        }



        private bool AtsiliepimaiExists(int id)
        {
            return _context.Atsiliepimais.Any(e => e.atsiliepimoId == id);
        }
    }
}