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
    public class MedziagosController : Controller
    {
        private readonly SistemosCtx _context;

        public MedziagosController(SistemosCtx context)
        {
            _context = context;
        }

        // GET: Medziagos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medziagos.ToListAsync());
        }

        // GET: Medziagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medziagos = await _context.Medziagos
                .FirstOrDefaultAsync(m => m.medziagosId == id);
            if (medziagos == null)
            {
                return NotFound();
            }

            return View(medziagos);
        }

        // GET: Medziagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medziagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("medziagosId,medziaga")] Medziagos medziagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medziagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medziagos);
        }

        // GET: Medziagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medziagos = await _context.Medziagos.FindAsync(id);
            if (medziagos == null)
            {
                return NotFound();
            }
            return View(medziagos);
        }

        // POST: Medziagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("medziagosId,medziaga")] Medziagos medziagos)
        {
            if (id != medziagos.medziagosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medziagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedziagosExists(medziagos.medziagosId))
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
            return View(medziagos);
        }

        // GET: Medziagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medziagos = await _context.Medziagos
                .FirstOrDefaultAsync(m => m.medziagosId == id);
            if (medziagos == null)
            {
                return NotFound();
            }

            return View(medziagos);
        }

        // POST: Medziagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medziagos = await _context.Medziagos.FindAsync(id);
            _context.Medziagos.Remove(medziagos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedziagosExists(int id)
        {
            return _context.Medziagos.Any(e => e.medziagosId == id);
        }
    }
}
