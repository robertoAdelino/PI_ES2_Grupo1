﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Controllers
{
    public class MaterialcsController : Controller
    {
        private readonly EquipamentoDbContext _context;

        public MaterialcsController(EquipamentoDbContext context)
        {
            _context = context;
        }

        // GET: Materialcs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materialcs.ToListAsync());
        }

        // GET: Materialcs/Details/5
        public async Task<IActionResult> Details(string id)
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
        public async Task<IActionResult> Edit(string id)
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
        public async Task<IActionResult> Edit(string id, [Bind("MaterialcsId,Nome,Quantidade")] Materialcs materialcs)
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
        public async Task<IActionResult> Delete(string id)
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
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var materialcs = await _context.Materialcs.FindAsync(id);
            _context.Materialcs.Remove(materialcs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialcsExists(string id)
        {
            return _context.Materialcs.Any(e => e.MaterialcsId == id);
        }
    }
}
