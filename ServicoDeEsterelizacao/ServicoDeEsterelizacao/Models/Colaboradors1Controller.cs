using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ServicoDeEsterelizacao.Models
{
    public class Colaboradors1Controller : Controller
    {
        private readonly ColaboradorDbContext _context;

        public Colaboradors1Controller(ColaboradorDbContext context)
        {
            _context = context;
        }

        // GET: Colaboradors1
        public async Task<IActionResult> Index()
        {
            var colaboradorDbContext = _context.Colaborador.Include(c => c.AssistenteOperacional).Include(c => c.DirServico).Include(c => c.Enfermeiro);
            return View(await colaboradorDbContext.ToListAsync());
        }

        // GET: Colaboradors1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.AssistenteOperacional)
                .Include(c => c.DirServico)
                .Include(c => c.Enfermeiro)
                .FirstOrDefaultAsync(m => m.AssisOperID == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradors1/Create
        public IActionResult Create()
        {
            ViewData["AssisOperID"] = new SelectList(_context.AssistenteOperacional, "AssistenteOperacionalID", "AssistenteOperacionalID");
            ViewData["DirID"] = new SelectList(_context.DiretorServico, "DiretorServicoID", "DiretorServicoID");
            ViewData["EnfermeiroID"] = new SelectList(_context.Enfermeiros, "EnfermeirosID", "EnfermeirosID");
            return View();
        }

        // POST: Colaboradors1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorId,Dest,funcao,EnfermeiroID,AssisOperID,DirID")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssisOperID"] = new SelectList(_context.AssistenteOperacional, "AssistenteOperacionalID", "AssistenteOperacionalID", colaborador.AssisOperID);
            ViewData["DirID"] = new SelectList(_context.DiretorServico, "DiretorServicoID", "DiretorServicoID", colaborador.DirID);
            ViewData["EnfermeiroID"] = new SelectList(_context.Enfermeiros, "EnfermeirosID", "EnfermeirosID", colaborador.EnfermeiroID);
            return View(colaborador);
        }

        // GET: Colaboradors1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            ViewData["AssisOperID"] = new SelectList(_context.AssistenteOperacional, "AssistenteOperacionalID", "AssistenteOperacionalID", colaborador.AssisOperID);
            ViewData["DirID"] = new SelectList(_context.DiretorServico, "DiretorServicoID", "DiretorServicoID", colaborador.DirID);
            ViewData["EnfermeiroID"] = new SelectList(_context.Enfermeiros, "EnfermeirosID", "EnfermeirosID", colaborador.EnfermeiroID);
            return View(colaborador);
        }

        // POST: Colaboradors1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,Dest,funcao,EnfermeiroID,AssisOperID,DirID")] Colaborador colaborador)
        {
            if (id != colaborador.AssisOperID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(colaborador.AssisOperID))
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
            ViewData["AssisOperID"] = new SelectList(_context.AssistenteOperacional, "AssistenteOperacionalID", "AssistenteOperacionalID", colaborador.AssisOperID);
            ViewData["DirID"] = new SelectList(_context.DiretorServico, "DiretorServicoID", "DiretorServicoID", colaborador.DirID);
            ViewData["EnfermeiroID"] = new SelectList(_context.Enfermeiros, "EnfermeirosID", "EnfermeirosID", colaborador.EnfermeiroID);
            return View(colaborador);
        }

        // GET: Colaboradors1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.AssistenteOperacional)
                .Include(c => c.DirServico)
                .Include(c => c.Enfermeiro)
                .FirstOrDefaultAsync(m => m.AssisOperID == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaboradors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);
            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaborador.Any(e => e.AssisOperID == id);
        }
    }
}
