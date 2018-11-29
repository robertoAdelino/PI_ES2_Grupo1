using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Controllers
{
    public class FuncaoController : Controller
    {
        private readonly MaterialDbContext _context;

        public FuncaoController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Funcao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcao.ToListAsync());
        }

        // GET: Funcao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao
                .FirstOrDefaultAsync(m => m.FuncaoID == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // GET: Funcao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncaoID,Nome")] Funcao funcao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcao);
        }

        // GET: Funcao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao.FindAsync(id);
            if (funcao == null)
            {
                return NotFound();
            }
            return View(funcao);
        }

        // POST: Funcao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncaoID,Nome")] Funcao funcao)
        {
            if (id != funcao.FuncaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncaoExists(funcao.FuncaoID))
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
            return View(funcao);
        }

        // GET: Funcao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcao = await _context.Funcao
                .FirstOrDefaultAsync(m => m.FuncaoID == id);
            if (funcao == null)
            {
                return NotFound();
            }

            return View(funcao);
        }

        // POST: Funcao/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcao = await _context.Funcao.FindAsync(id);
            _context.Funcao.Remove(funcao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncaoExists(int id)
        {
            return _context.Funcao.Any(e => e.FuncaoID == id);
        }
    }
}
