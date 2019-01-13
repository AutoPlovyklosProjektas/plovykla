using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plovykla.Models;

namespace Plovykla.Controllers
{
    public class VartotojaisController : Controller
    {
        private readonly SistemosCtx _context;

        public VartotojaisController(SistemosCtx context)
        {
            _context = context;
        }
        #region pagr
        // GET: Vartotojais
        public async Task<IActionResult> Index()
        {
            var sistemosCtx = _context.Vartotojais.Include(v => v.Kategorija);
            return View(await sistemosCtx.ToListAsync());
        }

        // GET: Vartotojais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vartotojai = await _context.Vartotojais
                .Include(v => v.Kategorija)
                .FirstOrDefaultAsync(m => m.vartotojoId == id);
            if (vartotojai == null)
            {
                return NotFound();
            }

            return View(vartotojai);
        }
        #endregion

        #region sukurimai
        // GET: Vartotojais/Create
        public IActionResult Create()
        {
            ViewData["kategorijosId"] = new SelectList(_context.Kategorijas, "kategorijosId", "kategorijosId");
            return View();
        }

        // POST: Vartotojais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vartotojoId,username,password,vardas,pavarde,email,kategorijosId")] Vartotojai vartotojai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vartotojai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["kategorijosId"] = new SelectList(_context.Kategorijas, "kategorijosId", "kategorijosId", vartotojai.kategorijosId);
            return View(vartotojai);
        }

        public IActionResult CreateDarb(string success)
        {
            ViewBag.success = success;
            try
            {
               string error =  HttpContext.Session.GetString("errorCreateDarb");
                ViewData["Error"] = error;
            }
            catch
            {
                ViewData["Error"] = " ";
            }
            return View();
        }

        [HttpPost,ActionName("CreateDarb")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDarb([Bind("vartotojoId,username,password,vardas,pavarde,email")] Vartotojai vartotojai)
        {
            if (ModelState.IsValid)
            {
                var vartotojaiUsername = (from s in _context.Vartotojais
                                          where s.username == vartotojai.username 
                                          select s).FirstOrDefault<Vartotojai>();

                var vartotojaiEmail = (from s in _context.Vartotojais
                                          where s.email == vartotojai.email
                                          select s).FirstOrDefault<Vartotojai>();
                if(vartotojaiUsername == null && vartotojaiEmail == null)
                {
                    vartotojai.kategorijosId = 2;
                    _context.Add(vartotojai);
                    _context.SaveChangesAsync();
                    return RedirectToAction(nameof(CreateDarb), new { success = "Naujo darbuotojo pridėjimas sėkmingas." });
                }

                else
                {
                    if (vartotojaiUsername != null && vartotojaiEmail != null)
                    {
                        HttpContext.Session.SetString("errorCreateDarb", "Prisijungimo vardas ir email uzimtas!");
                        return RedirectToAction("CreateDarb", "Vartotojais");
                    }
                    if (vartotojaiUsername != null)
                    {
                        HttpContext.Session.SetString("errorCreateDarb", "Prisijungimo vardas uzimtas!");
                        return RedirectToAction("CreateDarb", "Vartotojais");
                    }
                    if(vartotojaiEmail != null)
                    {
                        HttpContext.Session.SetString("errorCreateDarb", "Email uzimtas!");
                        return RedirectToAction("CreateDarb", "Vartotojais");
                    }

                }

            }
           return View(vartotojai);
        }
        #endregion


        #region editai
        // GET: Vartotojais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vartotojai = await _context.Vartotojais.FindAsync(id);
            if (vartotojai == null)
            {
                return NotFound();
            }
            ViewData["kategorijosId"] = new SelectList(_context.Kategorijas, "kategorijosId", "kategorijosId", vartotojai.kategorijosId);
            return View(vartotojai);
        }

        // POST: Vartotojais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("vartotojoId,username,password,vardas,pavarde,email,kategorijosId")] Vartotojai vartotojai)
        {
            if (id != vartotojai.vartotojoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vartotojai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VartotojaiExists(vartotojai.vartotojoId))
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
            ViewData["kategorijosId"] = new SelectList(_context.Kategorijas, "kategorijosId", "kategorijosId", vartotojai.kategorijosId);
            return View(vartotojai);
        }


        public IActionResult EditDarbuotojasForm()
        {
            var vartotojai = _context.Vartotojais.Where(s => s.kategorijosId == 2);
            return View(vartotojai.ToList());
        }
        #endregion

        #region salinimai
        // GET: Vartotojais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vartotojai = await _context.Vartotojais
                .Include(v => v.Kategorija)
                .FirstOrDefaultAsync(m => m.vartotojoId == id);
            if (vartotojai == null)
            {
                return NotFound();
            }

            return View(vartotojai);
        }

        // POST: Vartotojais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vartotojai = await _context.Vartotojais.FindAsync(id);
            _context.Vartotojais.Remove(vartotojai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EditDarbuotojasForm));
        }
        #endregion
        private bool VartotojaiExists(int id)
        {
            return _context.Vartotojais.Any(e => e.vartotojoId == id);
        }
    }
}
