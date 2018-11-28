using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Controllers
{
    [Authorize]
    public class ColaboradorController : Controller
    {
        private readonly MaterialDbContext _context;

        public ColaboradorController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Colaborador
        public async Task<IActionResult> Index()
        {
            var materialDbContext = _context.Colaborador.Include(c => c.Funcao);
            return View(await materialDbContext.ToListAsync());
        }

        // GET: Colaborador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Funcao)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaborador/Create
        [Authorize(Policy = "OnlyAdminAccess")]
        public IActionResult Create()
        {
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome");
            return View();
        }

        // POST: Colaborador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "OnlyAdminAccess")]
        public async Task<IActionResult> Create([Bind("ColaboradorId,FuncaoID,Nome,Telefone,Email,Morada,DataNasc,Filhos,DataNascFilho,Cc")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome", colaborador.FuncaoID);
            return View(colaborador);
        }

        // GET: Colaborador/Edit/5
        [Authorize(Policy = "OnlyAdminAccess")]
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
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome", colaborador.FuncaoID);
            return View(colaborador);
        }

        // POST: Colaborador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "OnlyAdminAccess")]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,FuncaoID,Nome,Telefone,Email,Morada,DataNasc,Filhos,DataNascFilho,Cc")] Colaborador colaborador)
        {
            if (id != colaborador.ColaboradorId)
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
                    if (!ColaboradorExists(colaborador.ColaboradorId))
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
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome", colaborador.FuncaoID);
            return View(colaborador);
        }

        // GET: Colaborador/Delete/5
        [Authorize(Policy = "OnlyAdminAccess")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Funcao)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "OnlyAdminAccess")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);
            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaborador.Any(e => e.ColaboradorId == id);
        }
    }
}
