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
    public class MaterialcsController : Controller
    {
        private readonly MaterialDbContext _context;
        private const int PAGE_SIZE = 10;
        public MaterialcsController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Materialcs
        public async Task<IActionResult> Index(MaterialListView model = null, int page = 1)
        {
            string Material = null;

            if (model != null)
            {
                Material = model.CurrentMaterial;
            }

            var material = _context.Materialcs
                .Where(p => Material == null || p.Nome.Contains(Material));

            int numProducts = await material.CountAsync();

            if (page > (numProducts / PAGE_SIZE) + 1)
            {
                page = 1;
            }
            var TipoList = await material
                    .OrderBy(p => p.Nome)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();

            return View(
                new MaterialListView
                {
                    Materialcs = TipoList,
                    Pagination = new PagingViewModel
                    {
                        CurrentPage = page,
                        PageSize = PAGE_SIZE,
                        Totaltems = numProducts
                    },
                    CurrentMaterial = Material
                }
            );
        }

        // GET: Materialcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialcs = await _context.Materialcs
                .FirstOrDefaultAsync(m => m.MaterialcsId == id);
            if (materialcs == null)
            {
                return NotFound();
            }

            return View(materialcs);
        }

        // GET: Materialcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materialcs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialcsId,Nome,Quantidade")] Materialcs materialcs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialcs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialcs);
        }

        // GET: Materialcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialcs = await _context.Materialcs.FindAsync(id);
            if (materialcs == null)
            {
                return NotFound();
            }
            return View(materialcs);
        }

        // POST: Materialcs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialcsId,Nome,Quantidade")] Materialcs materialcs)
        {
            if (id != materialcs.MaterialcsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialcs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialcsExists(materialcs.MaterialcsId))
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
            return View(materialcs);
        }

        // GET: Materialcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialcs = await _context.Materialcs
                .FirstOrDefaultAsync(m => m.MaterialcsId == id);
            if (materialcs == null)
            {
                return NotFound();
            }

            return View(materialcs);
        }

        // POST: Materialcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialcs = await _context.Materialcs.FindAsync(id);
            _context.Materialcs.Remove(materialcs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialcsExists(int id)
        {
            return _context.Materialcs.Any(e => e.MaterialcsId == id);
        }
    }
}
