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
    public class BusenosController : Controller
    {
        private readonly SistemosCtx _context;

        public BusenosController(SistemosCtx context)
        {
            _context = context;
        }

        // GET: Busenos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Busenos.ToListAsync());
        }

        // GET: Busenos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busenos = await _context.Busenos
                .FirstOrDefaultAsync(m => m.busenosId == id);
            if (busenos == null)
            {
                return NotFound();
            }

            return View(busenos);
        }

        // GET: Busenos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Busenos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("busenosId,busena")] Busenos busenos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busenos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(busenos);
        }

        // GET: Busenos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busenos = await _context.Busenos.FindAsync(id);
            if (busenos == null)
            {
                return NotFound();
            }
            return View(busenos);
        }

        // POST: Busenos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("busenosId,busena")] Busenos busenos)
        {
            if (id != busenos.busenosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busenos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusenosExists(busenos.busenosId))
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
            return View(busenos);
        }

        // GET: Busenos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busenos = await _context.Busenos
                .FirstOrDefaultAsync(m => m.busenosId == id);
            if (busenos == null)
            {
                return NotFound();
            }

            return View(busenos);
        }

        // POST: Busenos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busenos = await _context.Busenos.FindAsync(id);
            _context.Busenos.Remove(busenos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusenosExists(int id)
        {
            return _context.Busenos.Any(e => e.busenosId == id);
        }
    }
}
