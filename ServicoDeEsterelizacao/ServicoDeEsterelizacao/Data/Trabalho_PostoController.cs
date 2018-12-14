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
    public class Trabalho_PostoController : Controller
    {
        private readonly MaterialDbContext _context;

        public Trabalho_PostoController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Trabalho_Posto
        public async Task<IActionResult> Index()
        {
            var materialDbContext = _context.Trabalho_Posto.Include(t => t.Equipamento).Include(t => t.Horario).Include(t => t.Materialcs);
            return View(await materialDbContext.ToListAsync());
        }

        // GET: Trabalho_Posto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho_Posto = await _context.Trabalho_Posto
                .Include(t => t.Equipamento)
                .Include(t => t.Horario)
                .Include(t => t.Materialcs)
                .FirstOrDefaultAsync(m => m.MaterialcsID == id);
            if (trabalho_Posto == null)
            {
                return NotFound();
            }

            return View(trabalho_Posto);
        }

        // GET: Trabalho_Posto/Create
        public IActionResult Create()
        {
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID");
            ViewData["HorarioID"] = new SelectList(_context.Horario, "HorarioID", "HorarioID");
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome");
            return View();
        }

        // POST: Trabalho_Posto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Trabalho_PostoID,EquipamentoID,MaterialcsID,Estado,HorarioID,DataServico")] Trabalho_Posto trabalho_Posto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabalho_Posto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID", trabalho_Posto.EquipamentoID);
            ViewData["HorarioID"] = new SelectList(_context.Horario, "HorarioID", "HorarioID", trabalho_Posto.HorarioID);
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome", trabalho_Posto.MaterialcsID);
            return View(trabalho_Posto);
        }

        // GET: Trabalho_Posto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho_Posto = await _context.Trabalho_Posto.FindAsync(id);
            if (trabalho_Posto == null)
            {
                return NotFound();
            }
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID", trabalho_Posto.EquipamentoID);
            ViewData["HorarioID"] = new SelectList(_context.Horario, "HorarioID", "HorarioID", trabalho_Posto.HorarioID);
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome", trabalho_Posto.MaterialcsID);
            return View(trabalho_Posto);
        }

        // POST: Trabalho_Posto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Trabalho_PostoID,EquipamentoID,MaterialcsID,Estado,HorarioID,DataServico")] Trabalho_Posto trabalho_Posto)
        {
            if (id != trabalho_Posto.MaterialcsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabalho_Posto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Trabalho_PostoExists(trabalho_Posto.MaterialcsID))
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
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID", trabalho_Posto.EquipamentoID);
            ViewData["HorarioID"] = new SelectList(_context.Horario, "HorarioID", "HorarioID", trabalho_Posto.HorarioID);
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome", trabalho_Posto.MaterialcsID);
            return View(trabalho_Posto);
        }

        // GET: Trabalho_Posto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho_Posto = await _context.Trabalho_Posto
                .Include(t => t.Equipamento)
                .Include(t => t.Horario)
                .Include(t => t.Materialcs)
                .FirstOrDefaultAsync(m => m.MaterialcsID == id);
            if (trabalho_Posto == null)
            {
                return NotFound();
            }

            return View(trabalho_Posto);
        }

        // POST: Trabalho_Posto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabalho_Posto = await _context.Trabalho_Posto.FindAsync(id);
            _context.Trabalho_Posto.Remove(trabalho_Posto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Trabalho_PostoExists(int id)
        {
            return _context.Trabalho_Posto.Any(e => e.MaterialcsID == id);
        }
    }
}
