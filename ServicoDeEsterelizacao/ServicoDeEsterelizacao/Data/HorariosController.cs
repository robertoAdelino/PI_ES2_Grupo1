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
    public class HorariosController : Controller
    {
        private readonly MaterialDbContext _context;

        public HorariosController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var materialDbContext = _context.Horario.Include(h => h.Colaborador).Include(h => h.Posto).Include(h => h.Turno);
            return View(await materialDbContext.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Colaborador)
                .Include(h => h.Posto)
                .Include(h => h.Turno)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "FuncaoID", "Cc");
            ViewData["PostoId"] = new SelectList(_context.Set<Posto>(), "PostoId", "Nome");
            ViewData["TurnoId"] = new SelectList(_context.Set<Turno>(), "TurnoId", "Nome");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HorarioID,Data,TurnoId,PostoId,ColaboradorId")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "FuncaoID", "Cc", horario.ColaboradorId);
            ViewData["PostoId"] = new SelectList(_context.Set<Posto>(), "PostoId", "Nome", horario.PostoId);
            ViewData["TurnoId"] = new SelectList(_context.Set<Turno>(), "TurnoId", "Nome", horario.TurnoId);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "FuncaoID", "Cc", horario.ColaboradorId);
            ViewData["PostoId"] = new SelectList(_context.Set<Posto>(), "PostoId", "Nome", horario.PostoId);
            ViewData["TurnoId"] = new SelectList(_context.Set<Turno>(), "TurnoId", "Nome", horario.TurnoId);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HorarioID,Data,TurnoId,PostoId,ColaboradorId")] Horario horario)
        {
            if (id != horario.HorarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.HorarioID))
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "FuncaoID", "Cc", horario.ColaboradorId);
            ViewData["PostoId"] = new SelectList(_context.Set<Posto>(), "PostoId", "Nome", horario.PostoId);
            ViewData["TurnoId"] = new SelectList(_context.Set<Turno>(), "TurnoId", "Nome", horario.TurnoId);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Colaborador)
                .Include(h => h.Posto)
                .Include(h => h.Turno)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horario.FindAsync(id);
            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.HorarioID == id);
        }
    }
}
