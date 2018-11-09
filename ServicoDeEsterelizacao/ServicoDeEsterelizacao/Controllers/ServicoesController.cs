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
    public class ServicoesController : Controller
    {
        private readonly ServicoDbContext _context;

        public ServicoesController(ServicoDbContext context)
        {
            _context = context;
        }

        // GET: Servicoes
        public async Task<IActionResult> Index()
        {
            var servicoDbContext = _context.Servicos.Include(s => s.Colaborador).Include(s => s.Horario);
            return View(await servicoDbContext.ToListAsync());
        }

        // GET: Servicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .Include(s => s.Colaborador)
                .Include(s => s.Horario)
                .FirstOrDefaultAsync(m => m.ServicoID == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // GET: Servicoes/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorID"] = new SelectList(_context.Colaboradores, "ColaboradorId", "ColaboradorId");
            ViewData["HorarioID"] = new SelectList(_context.Horarios, "HorarioID", "HorarioID");
            return View();
        }

        // POST: Servicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicoID,data,ColaboradorID,HorarioID")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorID"] = new SelectList(_context.Colaboradores, "ColaboradorId", "ColaboradorId", servico.ColaboradorID);
            ViewData["HorarioID"] = new SelectList(_context.Horarios, "HorarioID", "HorarioID", servico.HorarioID);
            return View(servico);
        }

        // GET: Servicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorID"] = new SelectList(_context.Colaboradores, "ColaboradorId", "ColaboradorId", servico.ColaboradorID);
            ViewData["HorarioID"] = new SelectList(_context.Horarios, "HorarioID", "HorarioID", servico.HorarioID);
            return View(servico);
        }

        // POST: Servicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicoID,data,ColaboradorID,HorarioID")] Servico servico)
        {
            if (id != servico.ServicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.ServicoID))
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
            ViewData["ColaboradorID"] = new SelectList(_context.Colaboradores, "ColaboradorId", "ColaboradorId", servico.ColaboradorID);
            ViewData["HorarioID"] = new SelectList(_context.Horarios, "HorarioID", "HorarioID", servico.HorarioID);
            return View(servico);
        }

        // GET: Servicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .Include(s => s.Colaborador)
                .Include(s => s.Horario)
                .FirstOrDefaultAsync(m => m.ServicoID == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // POST: Servicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicoExists(int id)
        {
            return _context.Servicos.Any(e => e.ServicoID == id);
        }
    }
}
