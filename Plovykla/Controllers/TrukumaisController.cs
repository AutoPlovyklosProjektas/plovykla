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
    public class TrukumaisController : Controller
    {
        private readonly SistemosCtx _context;

        public TrukumaisController(SistemosCtx context)
        {
            _context = context;
        }

        // GET: Trukumais
        public async Task<IActionResult> Index()
        {
            var sistemosCtx = _context.Trukumais.Include(t => t.Medziagos);
            return View(await sistemosCtx.ToListAsync());
        }

        // GET: Trukumais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trukumai = await _context.Trukumais
                .Include(t => t.Medziagos)
                .FirstOrDefaultAsync(m => m.trukumoId == id);
            if (trukumai == null)
            {
                return NotFound();
            }

            return View(trukumai);
        }

        // GET: Trukumais/Create
        public IActionResult Create()
        {
            ViewData["medziagosId"] = new SelectList(_context.Medziagos, "medziagosId", "medziagosId");
            return View();
        }

        // POST: Trukumais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("trukumoId,medziagosId")] Trukumai trukumai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trukumai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["medziagosId"] = new SelectList(_context.Medziagos, "medziagosId", "medziagosId", trukumai.medziagosId);
            return View(trukumai);
        }

        // GET: Trukumais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trukumai = await _context.Trukumais.FindAsync(id);
            if (trukumai == null)
            {
                return NotFound();
            }
            ViewData["medziagosId"] = new SelectList(_context.Medziagos, "medziagosId", "medziagosId", trukumai.medziagosId);
            return View(trukumai);
        }

        // POST: Trukumais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("trukumoId,medziagosId")] Trukumai trukumai)
        {
            if (id != trukumai.trukumoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trukumai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrukumaiExists(trukumai.trukumoId))
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
            ViewData["medziagosId"] = new SelectList(_context.Medziagos, "medziagosId", "medziagosId", trukumai.medziagosId);
            return View(trukumai);
        }

        // GET: Trukumais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trukumai = await _context.Trukumais
                .Include(t => t.Medziagos)
                .FirstOrDefaultAsync(m => m.trukumoId == id);
            if (trukumai == null)
            {
                return NotFound();
            }

            return View(trukumai);
        }

        // POST: Trukumais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trukumai = await _context.Trukumais.FindAsync(id);
            _context.Trukumais.Remove(trukumai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrukumaiExists(int id)
        {
            return _context.Trukumais.Any(e => e.trukumoId == id);
        }
    }
}
