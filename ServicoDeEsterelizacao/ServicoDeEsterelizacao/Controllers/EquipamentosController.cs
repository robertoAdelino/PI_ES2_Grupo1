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

    public class EquipamentosController : Controller
    {
        private readonly MaterialDbContext _context;
        private const int PAGE_SIZE = 5;
        public EquipamentosController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Equipamentos
        public async Task<IActionResult> Index(EquipamentoListView model = null, int page = 1, string order = null)
        {
            string Equipamento = null;

            if (model != null)
            {
                Equipamento = model.CurrentEquipamento;
            }

            var equipamento = _context.Equipamento
                .Where(p => Equipamento == null || p.Tipo.Nome.Contains(Equipamento));

            int numProducts = await equipamento.CountAsync();

            if (page > (numProducts / PAGE_SIZE) + 1)
            {
                page = 1;
            }
            IEnumerable<Equipamento> TipoList;
            if (order == "TipoID")
            {
                TipoList = await equipamento
                        .OrderBy(p => p.TipoID)
                        .Skip(PAGE_SIZE * (page - 1))
                        .Take(PAGE_SIZE)
                        .ToListAsync();
            }
            else if (order == "Capacidade")
            {
                TipoList = await equipamento
                        .OrderBy(p => p.Capacidade)
                        .Skip(PAGE_SIZE * (page - 1))
                        .Take(PAGE_SIZE)
                        .ToListAsync();
            }
            else if(order == "ID")
            {
                TipoList = await equipamento
                          .OrderBy(p => p.EquipamentoID)
                          .Skip(PAGE_SIZE * (page - 1))
                          .Take(PAGE_SIZE)
                          .ToListAsync();
            } 
            else
            {
                TipoList = await equipamento
                          .OrderBy(p => p.EquipamentoID)
                          .Skip(PAGE_SIZE * (page - 1))
                          .Take(PAGE_SIZE)
                          .ToListAsync();
            }
            return View(
                new EquipamentoListView
                {
                    Equipamento = TipoList,
                    Pagination = new PagingViewModel
                    {
                        CurrentPage = page,
                        PageSize = PAGE_SIZE,
                        Totaltems = numProducts,
                        Order = order
                    },
                    CurrentEquipamento = Equipamento
                }
            );
        }

        // GET: Equipamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamento
                .Include(e => e.Tipo)
                .FirstOrDefaultAsync(m => m.EquipamentoID == id);
            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        // GET: Equipamentos/Create
        public IActionResult Create()
        {
            ViewData["TipoID"] = new SelectList(_context.Tipo, "TipoID", "Nome");
            return View();
        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipamentoID,Capacidade,TipoID")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoID"] = new SelectList(_context.Tipo, "TipoID", "Nome", equipamento.TipoID);
            return View(equipamento);
        }

        // GET: Equipamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamento.FindAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            ViewData["TipoID"] = new SelectList(_context.Tipo, "TipoID", "Nome", equipamento.TipoID);
            return View(equipamento);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipamentoID,Capacidade,TipoID")] Equipamento equipamento)
        {
            if (id != equipamento.EquipamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamentoExists(equipamento.EquipamentoID))
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
            ViewData["TipoID"] = new SelectList(_context.Tipo, "TipoID", "Nome", equipamento.TipoID);
            return View(equipamento);
        }

        // GET: Equipamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamento
                .Include(e => e.Tipo)
                .FirstOrDefaultAsync(m => m.EquipamentoID == id);
            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipamento = await _context.Equipamento.FindAsync(id);
            _context.Equipamento.Remove(equipamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipamentoExists(int id)
        {
            return _context.Equipamento.Any(e => e.EquipamentoID == id);
        }
    }
}
