using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plovykla.Models;

namespace Plovykla.Controllers
{
    public class BaudosController : Controller
    {
        private readonly SistemosCtx _context;

        public BaudosController(SistemosCtx context)
        {
            _context = context;
        }

        // GET: Baudos
        public async Task<IActionResult> Index()
        {
            var sistemosCtx = _context.Baudos.Include(b => b.Uzsakymas).Include(b => b.Vartotojai);
            return View(await sistemosCtx.ToListAsync());
        }

        // GET: Baudos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baudos = await _context.Baudos
                .Include(b => b.Uzsakymas)
                .Include(b => b.Vartotojai)
                .FirstOrDefaultAsync(m => m.baudosId == id);
            if (baudos == null)
            {
                return NotFound();
            }

            return View(baudos);
        }

        // GET: Baudos/Create
        public IActionResult Create()
        {
            ViewData["uzsakymoId"] = new SelectList(_context.Uzsakymas, "uzsakymoId", "uzsakymoId");
            ViewData["vartotojoId"] = new SelectList(_context.Vartotojais.Where(s=>s.kategorijosId ==2), "vartotojoId", "vardas");
            return View();
        }

        // POST: Baudos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("baudosId,baudosAprasymas,nuostolis,data,vartotojoId,uzsakymoId")] Baudos baudos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baudos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["uzsakymoId"] = new SelectList(_context.Uzsakymas, "uzsakymoId", "uzsakymoId", baudos.uzsakymoId);
            ViewData["vartotojoId"] = new SelectList(_context.Vartotojais, "vartotojoId", "vartotojoId", baudos.vartotojoId);
            return View(baudos);
        }

        // GET: Baudos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baudos = await _context.Baudos.FindAsync(id);
            if (baudos == null)
            {
                return NotFound();
            }
            ViewData["uzsakymoId"] = new SelectList(_context.Uzsakymas, "uzsakymoId", "uzsakymoId", baudos.uzsakymoId);
            ViewData["vartotojoId"] = new SelectList(_context.Vartotojais, "vartotojoId", "vartotojoId", baudos.vartotojoId);
            return View(baudos);
        }

        // POST: Baudos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("baudosId,baudosAprasymas,nuostolis,data,vartotojoId,uzsakymoId")] Baudos baudos)
        {
            if (id != baudos.baudosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baudos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaudosExists(baudos.baudosId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["uzsakymoId"] = new SelectList(_context.Uzsakymas, "uzsakymoId", "uzsakymoId", baudos.uzsakymoId);
            ViewData["vartotojoId"] = new SelectList(_context.Vartotojais, "vartotojoId", "vartotojoId", baudos.vartotojoId);
            return View(baudos);
        }

        // GET: Baudos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baudos = await _context.Baudos
                .Include(b => b.Uzsakymas)
                .Include(b => b.Vartotojai)
                .FirstOrDefaultAsync(m => m.baudosId == id);
            if (baudos == null)
            {
                return NotFound();
            }

            return View(baudos);
        }

        // POST: Baudos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baudos = await _context.Baudos.FindAsync(id);
            _context.Baudos.Remove(baudos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaudosExists(int id)
        {
            return _context.Baudos.Any(e => e.baudosId == id);
        }
    }
}
