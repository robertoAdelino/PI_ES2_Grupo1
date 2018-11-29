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
    public class ColaboradoresController : Controller
    {
        private readonly MaterialDbContext _context;

        public ColaboradoresController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Colaboradores
        public async Task<IActionResult> Index()
        {
            var materialDbContext = _context.Colaborador.Include(c => c.Funcao);
            return View(await materialDbContext.ToListAsync());
        }

        // GET: Colaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Funcao)
                .FirstOrDefaultAsync(m => m.FuncaoID == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradores/Create
        public IActionResult Create()
        {
            ViewData["FuncaoID"] = new SelectList(_context.Funcao, "FuncaoID", "Nome");
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorId,FuncaoID,Nome,Telefone,Email,Morada,DataNasc,Cc")] Colaborador colaborador)
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

        // GET: Colaboradores/Edit/5
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

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,FuncaoID,Nome,Telefone,Email,Morada,DataNasc,Cc")] Colaborador colaborador)
        {
            if (id != colaborador.FuncaoID)
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
                    if (!ColaboradorExists(colaborador.FuncaoID))
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

        // GET: Colaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Funcao)
                .FirstOrDefaultAsync(m => m.FuncaoID == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaboradores/Delete/5
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
            return _context.Colaborador.Any(e => e.FuncaoID == id);
        }
    }
}
