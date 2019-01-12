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
    public class UzsakymasController : Controller
    {
        private readonly SistemosCtx _context;

        public UzsakymasController(SistemosCtx context)
        {
            _context = context;
        }


        #region pagrindinis
        // GET: Uzsakymas
        public async Task<IActionResult> Index()
        {
            var sistemosCtx = _context.Uzsakymas.Include(u => u.Busenos)
                .Include(u => u.Klientai)
                .Include(u => u.Paslauga)
                .Include(u => u.Vartotojai);
            return View(await sistemosCtx.ToListAsync());
        }

        // GET: Uzsakymas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzsakymas = await _context.Uzsakymas
                .Include(u => u.Busenos)
                .Include(u => u.Klientai)
                .Include(u => u.Paslauga)
                .Include(u => u.Vartotojai)
                .FirstOrDefaultAsync(m => m.uzsakymoId == id);
            if (uzsakymas == null)
            {
                return NotFound();
            }

            return View(uzsakymas);
        }

        #endregion

        #region create
        // GET: Uzsakymas/Create
        public IActionResult Create()
        {
           // ViewData["busenosId"] = new SelectList(_context.Busenos, "busenosId", "busenosId");
            ViewData["klientoId"] = new SelectList(_context.Vartotojais.Where(s => s.vartotojoId == 3), "vartotojoId", "username");
            ViewData["paslaugosId"] = new SelectList(_context.Paslaugas, "paslaugosId", "paslaugosId");
            ViewData["darbuotojoId"] = new SelectList(_context.Vartotojais.Where(s=>s.vartotojoId==2), "vartotojoId", "username");
            return View();
        }

        // POST: Uzsakymas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("uzsakymoId,uzsakymo_Data,uzsakymoKaina,paslaugosId,darbuotojoId,klientoId,busenosId")] Uzsakymas uzsakymas)
        {
            if (ModelState.IsValid)
            {
                uzsakymas.busenosId = 2;
                _context.Add(uzsakymas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["busenosId"] = new SelectList(_context.Busenos, "busenosId", "busenosId", uzsakymas.busenosId);
            //ViewData["klientoId"] = new SelectList(_context.Vartotojais, "vartotojoId", "vartotojoId", uzsakymas.klientoId);
            //ViewData["paslaugosId"] = new SelectList(_context.Paslaugas, "paslaugosId", "paslaugosId", uzsakymas.paslaugosId);
            //ViewData["darbuotojoId"] = new SelectList(_context.Vartotojais, "vartotojoId", "vartotojoId", uzsakymas.darbuotojoId);
            ViewData["klientoId"] = new SelectList(_context.Vartotojais.Where(s => s.vartotojoId == 3), "vartotojoId", "username");
            ViewData["paslaugosId"] = new SelectList(_context.Paslaugas, "paslaugosId", "paslaugosId");
            ViewData["darbuotojoId"] = new SelectList(_context.Vartotojais.Where(s => s.vartotojoId == 2), "vartotojoId", "username");
            return View(uzsakymas);
        }

        #endregion

        #region edit
        // GET: Uzsakymas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzsakymas = await _context.Uzsakymas.FindAsync(id);
            if (uzsakymas == null)
            {
                return NotFound();
            }
            ViewData["busenosId"] = new SelectList(_context.Busenos, "busenosId", "busenosId", uzsakymas.busenosId);
            ViewData["klientoId"] = new SelectList(_context.Vartotojais, "vartotojoId", "vartotojoId", uzsakymas.klientoId);
            ViewData["paslaugosId"] = new SelectList(_context.Paslaugas, "paslaugosId", "paslaugosId", uzsakymas.paslaugosId);
            ViewData["darbuotojoId"] = new SelectList(_context.Vartotojais, "vartotojoId", "vartotojoId", uzsakymas.darbuotojoId);
            return View(uzsakymas);
        }

        // POST: Uzsakymas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("uzsakymoId,uzsakymo_Data,uzsakymoKaina,paslaugosId,darbuotojoId,klientoId,busenosId")] Uzsakymas uzsakymas)
        {
            if (id != uzsakymas.uzsakymoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzsakymas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzsakymasExists(uzsakymas.uzsakymoId))
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
            ViewData["busenosId"] = new SelectList(_context.Busenos, "busenosId", "busenosId", uzsakymas.busenosId);
            ViewData["klientoId"] = new SelectList(_context.Vartotojais, "vartotojoId", "vartotojoId", uzsakymas.klientoId);
            ViewData["paslaugosId"] = new SelectList(_context.Paslaugas, "paslaugosId", "paslaugosId", uzsakymas.paslaugosId);
            ViewData["darbuotojoId"] = new SelectList(_context.Vartotojais, "vartotojoId", "vartotojoId", uzsakymas.darbuotojoId);
            return View(uzsakymas);
        }

        #endregion

        #region delete
        // GET: Uzsakymas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzsakymas = await _context.Uzsakymas
                .Include(u => u.Busenos)
                .Include(u => u.Klientai)
                .Include(u => u.Paslauga)
                .Include(u => u.Vartotojai)
                .FirstOrDefaultAsync(m => m.uzsakymoId == id);
            if (uzsakymas == null)
            {
                return NotFound();
            }

            return View(uzsakymas);
        }

        // POST: Uzsakymas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uzsakymas = await _context.Uzsakymas.FindAsync(id);
            _context.Uzsakymas.Remove(uzsakymas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region patvirtinimas uzsakymo
        public async Task<IActionResult> Patvirtinti()
        {
            var uzsakymai = _context.Uzsakymas.Include(u => u.Busenos).Where(s=>s.busenosId==1)
                           .Include(u => u.Klientai)
                           .Include(u => u.Paslauga)
                           .Include(u => u.Vartotojai);
            return View(uzsakymai.ToList());
        }

        [HttpPost,ActionName("PatvirtintiAct")]
        [ValidateAntiForgeryToken]
        public IActionResult PatvirtintiAct([Bind("uzsakymoId")] Uzsakymas uzsakymass)
        {
            if (uzsakymass != null)
            {
                var uzsakymas = _context.Uzsakymas.Find(uzsakymass.uzsakymoId);
                uzsakymas.busenosId = 2;
                try
                {
                    _context.Update(uzsakymas);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzsakymasExists(uzsakymas.uzsakymoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return RedirectToAction("Patvirtinti", "Uzsakymas");
        }

        #endregion

        #region darbuotojo pridejimas
        public async Task<IActionResult> DarbuotojoPridejimas()
        {
            var uzsakymai = _context.Uzsakymas.Include(u => u.Busenos)
                           .Include(u => u.Klientai)
                           .Include(u => u.Paslauga)
                           .Include(u => u.Vartotojai).Where(s=>s.darbuotojoId == null);
            return View(uzsakymai.ToList());
        }

        

        [HttpPost, ActionName("PridetiDarb")]
        [ValidateAntiForgeryToken]
        public IActionResult PridetiDarb([Bind("uzsakymoId")] Uzsakymas uzsakymass)
        {
            if (uzsakymass != null)
            {
                ViewData["id"] = uzsakymass.uzsakymoId;
                ViewData["darbuotojai"] = new SelectList(_context.Vartotojais.Where(s=>s.kategorijosId == 2), "vartotojoId","vardas",uzsakymass.darbuotojoId);
                return View();

                
            }
            return RedirectToAction("DarbuotojoPridejimas", "Uzsakymas");
        }

        [HttpPost, ActionName("PridetiDarbAct")]
        [ValidateAntiForgeryToken]
        public IActionResult PridetiDarbAct([Bind("uzsakymoId,darbuotojoId")] Uzsakymas uzsakymass)
        {
            if (uzsakymass != null)
            {
                var uzsakymas = _context.Uzsakymas.Find(uzsakymass.uzsakymoId);
                uzsakymas.darbuotojoId = uzsakymass.darbuotojoId;
                try
                {
                    _context.Update(uzsakymas);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzsakymasExists(uzsakymas.uzsakymoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("DarbuotojoPridejimas", "Uzsakymas");
        }


        #endregion

        #region pabaigimas

        public IActionResult UzsakymoPabaiga()
        {
            var uzsakymai = _context.Uzsakymas.Include(u => u.Busenos).Where(s=>s.busenosId==2)
               .Include(u => u.Klientai)
               .Include(u => u.Paslauga)
               .Include(u => u.Vartotojai);

            return View(uzsakymai.ToList());
        }

        [HttpPost, ActionName("uzsakymoPabaigimas")]
        [ValidateAntiForgeryToken]
        public IActionResult uzsakymoPabaigimas([Bind("uzsakymoId")] Uzsakymas uzsakymass)
        {
            if (uzsakymass != null)
            {
                var uzsakymas = _context.Uzsakymas.Find(uzsakymass.uzsakymoId);
                uzsakymas.busenosId = 3;
                try
                {
                    _context.Update(uzsakymas);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzsakymasExists(uzsakymas.uzsakymoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("UzsakymoPabaiga", "Uzsakymas");
        }
        #endregion
        private bool UzsakymasExists(int id)
        {
            return _context.Uzsakymas.Any(e => e.uzsakymoId == id);
        }
    }
}
