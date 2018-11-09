using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Controllers
{
    public class AssistenteOperacionalsController : Controller
    {
        private readonly ColaboradorDbContext _context;

        public AssistenteOperacionalsController(ColaboradorDbContext context)
        {
            _context = context;
        }

        // GET: AssistenteOperacionals
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssistenteOperacional.ToListAsync());
        }

        // GET: AssistenteOperacionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistenteOperacional = await _context.AssistenteOperacional
                .FirstOrDefaultAsync(m => m.AssistenteOperacionalID == id);
            if (assistenteOperacional == null)
            {
                return NotFound();
            }

            return View(assistenteOperacional);
        }

        // GET: AssistenteOperacionals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssistenteOperacionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssistenteOperacionalID,Nome")] AssistenteOperacional assistenteOperacional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assistenteOperacional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assistenteOperacional);
        }

        // GET: AssistenteOperacionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistenteOperacional = await _context.AssistenteOperacional.FindAsync(id);
            if (assistenteOperacional == null)
            {
                return NotFound();
            }
            return View(assistenteOperacional);
        }

        // POST: AssistenteOperacionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssistenteOperacionalID,Nome")] AssistenteOperacional assistenteOperacional)
        {
            if (id != assistenteOperacional.AssistenteOperacionalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assistenteOperacional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssistenteOperacionalExists(assistenteOperacional.AssistenteOperacionalID))
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
            return View(assistenteOperacional);
        }

        // GET: AssistenteOperacionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistenteOperacional = await _context.AssistenteOperacional
                .FirstOrDefaultAsync(m => m.AssistenteOperacionalID == id);
            if (assistenteOperacional == null)
            {
                return NotFound();
            }

            return View(assistenteOperacional);
        }

        // POST: AssistenteOperacionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assistenteOperacional = await _context.AssistenteOperacional.FindAsync(id);
            _context.AssistenteOperacional.Remove(assistenteOperacional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssistenteOperacionalExists(int id)
        {
            return _context.AssistenteOperacional.Any(e => e.AssistenteOperacionalID == id);
        }
    }
}
