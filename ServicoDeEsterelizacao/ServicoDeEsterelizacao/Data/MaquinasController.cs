using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Data
{
    public class MaquinasController : Controller
    {
        private readonly MaterialDbContext _context;

        public MaquinasController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Maquinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Maquinas.ToListAsync());
        }

        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquinas = await _context.Maquinas
                .FirstOrDefaultAsync(m => m.MaquinasId == id);
            if (maquinas == null)
            {
                return NotFound();
            }

            return View(maquinas);
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaquinasId,Capacidade,Quantidade")] Maquinas maquinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquinas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maquinas);
        }

        // GET: Maquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquinas = await _context.Maquinas.FindAsync(id);
            if (maquinas == null)
            {
                return NotFound();
            }
            return View(maquinas);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaquinasId,Capacidade,Quantidade")] Maquinas maquinas)
        {
            if (id != maquinas.MaquinasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinasExists(maquinas.MaquinasId))
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
            return View(maquinas);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquinas = await _context.Maquinas
                .FirstOrDefaultAsync(m => m.MaquinasId == id);
            if (maquinas == null)
            {
                return NotFound();
            }

            return View(maquinas);
        }

        // POST: Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maquinas = await _context.Maquinas.FindAsync(id);
            _context.Maquinas.Remove(maquinas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinasExists(int id)
        {
            return _context.Maquinas.Any(e => e.MaquinasId == id);
        }
    }
}
