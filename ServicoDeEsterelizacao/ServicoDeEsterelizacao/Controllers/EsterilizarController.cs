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
    public class EsterilizarController : Controller
    {
        private readonly MaterialDbContext _context;

        public EsterilizarController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Esterilizar
        public async Task<IActionResult> Index()
        {
            var materialDbContext = _context.Esterilizar.Include(e => e.Equipamento).Include(e => e.Materialcs);
            return View(await materialDbContext.ToListAsync());
        }

        // GET: Esterilizar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var esterilizar = await _context.Esterilizar
                .Include(e => e.Equipamento)
                .Include(e => e.Materialcs)
                .FirstOrDefaultAsync(m => m.MaterialcsID == id);
            if (esterilizar == null)
            {
                return NotFound();
            }

            return View(esterilizar);
        }

        // GET: Esterilizar/Create
        public IActionResult Create()
        {
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID");
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome");
            return View();
        }

        // POST: Esterilizar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EsterilizarID,EquipamentoID,MaterialcsID")] Trabalho_Posto esterilizar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(esterilizar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID", esterilizar.EquipamentoID);
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome", esterilizar.MaterialcsID);
            return View(esterilizar);
        }

        // GET: Esterilizar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var esterilizar = await _context.Esterilizar.FindAsync(id);
            if (esterilizar == null)
            {
                return NotFound();
            }
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID", esterilizar.EquipamentoID);
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome", esterilizar.MaterialcsID);
            return View(esterilizar);
        }

        // POST: Esterilizar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EsterilizarID,EquipamentoID,MaterialcsID")] Trabalho_Posto esterilizar)
        {
            if (id != esterilizar.MaterialcsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(esterilizar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EsterilizarExists(esterilizar.MaterialcsID))
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
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID", esterilizar.EquipamentoID);
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome", esterilizar.MaterialcsID);
            return View(esterilizar);
        }

        // GET: Esterilizar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var esterilizar = await _context.Esterilizar
                .Include(e => e.Equipamento)
                .Include(e => e.Materialcs)
                .FirstOrDefaultAsync(m => m.MaterialcsID == id);
            if (esterilizar == null)
            {
                return NotFound();
            }

            return View(esterilizar);
        }

        // POST: Esterilizar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var esterilizar = await _context.Esterilizar.FindAsync(id);
            _context.Esterilizar.Remove(esterilizar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EsterilizarExists(int id)
        {
            return _context.Esterilizar.Any(e => e.MaterialcsID == id);
        }
    }
}
