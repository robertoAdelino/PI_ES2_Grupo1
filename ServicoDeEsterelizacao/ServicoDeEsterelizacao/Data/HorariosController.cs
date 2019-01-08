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
        private const int PAGE_SIZE = 5;
        public HorariosController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index(HorarioViewList model = null, int page = 1)
        {
            string Horario = null;

            if (model != null)
            {
                Horario = model.CurrentColaborador;
            }

            var horario = _context.Horario
                .Where(p => Horario == null || p.Colaborador.Nome.Contains(Horario));

            int numProducts = await horario.CountAsync();

            if (page > (numProducts / PAGE_SIZE) + 1)
            {
                page = 1;
            }
            var TipoList = await horario
                    .OrderBy(p => p.ColaboradorId)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();

            return View(
                new HorarioViewList
                {
                    Horario = TipoList,
                    Pagination = new PagingViewModel
                    {
                        CurrentPage = page,
                        PageSize = PAGE_SIZE,
                        Totaltems = numProducts
                    },
                    CurrentColaborador = Horario
                }
            );
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Cc");
            ViewData["PostoId"] = new SelectList(_context.Posto, "PostoId", "Nome");
            ViewData["TurnoId"] = new SelectList(_context.Turno, "TurnoId", "Nome");
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Cc", horario.ColaboradorId);
            ViewData["PostoId"] = new SelectList(_context.Posto, "PostoId", "Nome", horario.PostoId);
            ViewData["TurnoId"] = new SelectList(_context.Turno, "TurnoId", "Nome", horario.TurnoId);
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Cc", horario.ColaboradorId);
            ViewData["PostoId"] = new SelectList(_context.Posto, "PostoId", "Nome", horario.PostoId);
            ViewData["TurnoId"] = new SelectList(_context.Turno, "TurnoId", "Nome", horario.TurnoId);
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Cc", horario.ColaboradorId);
            ViewData["PostoId"] = new SelectList(_context.Posto, "PostoId", "Nome", horario.PostoId);
            ViewData["TurnoId"] = new SelectList(_context.Turno, "TurnoId", "Nome", horario.TurnoId);
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
