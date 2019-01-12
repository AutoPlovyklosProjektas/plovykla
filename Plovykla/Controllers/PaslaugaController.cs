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
    public class PaslaugaController : Controller
    {
        private readonly SistemosCtx _context;

        public PaslaugaController(SistemosCtx context)
        {
            _context = context;
        }

        // GET: Paslauga
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paslaugas.ToListAsync());
        }

        // GET: Paslauga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paslauga = await _context.Paslaugas
                .FirstOrDefaultAsync(m => m.paslaugosId == id);
            if (paslauga == null)
            {
                return NotFound();
            }

            return View(paslauga);
        }

        // GET: Paslauga/Create
        public IActionResult Create(string success)
        {
            ViewBag.success = success;
            return View();
        }

        // POST: Paslauga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("paslaugosId,paslaugosKaina,paslaugosPavadinimas,paslaugosAprasymas")] Paslauga paslauga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paslauga);
                await _context.SaveChangesAsync();
                //ViewData["CreateSuccess"] = "Paslaugos pridėjimas sėkmingas.";
                return RedirectToAction(nameof(Create), new { success = "Paslaugos pridėjimas sėkmingas." });
            }
            return View(paslauga);
        }

        // GET: Paslauga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paslauga = await _context.Paslaugas.FindAsync(id);
            if (paslauga == null)
            {
                return NotFound();
            }
            return View(paslauga);
        }

        // POST: Paslauga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("paslaugosId,paslaugosKaina,paslaugosPavadinimas,paslaugosAprasymas")] Paslauga paslauga)
        {
            if (id != paslauga.paslaugosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paslauga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaslaugaExists(paslauga.paslaugosId))
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
            return View(paslauga);
        }

        // GET: Paslauga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paslauga = await _context.Paslaugas
                .FirstOrDefaultAsync(m => m.paslaugosId == id);
            if (paslauga == null)
            {
                return NotFound();
            }

            return View(paslauga);
        }

        // POST: Paslauga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paslauga = await _context.Paslaugas.FindAsync(id);
            _context.Paslaugas.Remove(paslauga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaslaugaExists(int id)
        {
            return _context.Paslaugas.Any(e => e.paslaugosId == id);
        }
    }
}
