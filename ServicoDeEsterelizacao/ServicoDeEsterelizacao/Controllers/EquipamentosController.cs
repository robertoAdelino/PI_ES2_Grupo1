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
    public class EquipamentosController : Controller
    {
        private readonly MaterialDbContext _context;

        public EquipamentosController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Equipamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipamento.ToListAsync());
        }

        // GET: Equipamentos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamento
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
            return View();
        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipamentoID,Nome,CapacidadeMax,CapacidadeMin,Quantidade,MaterialcsId")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipamento);
        }

        // GET: Equipamentos/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            return View(equipamento);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EquipamentoID,Nome,CapacidadeMax,CapacidadeMin,Quantidade,MaterialcsId")] Equipamento equipamento)
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
            return View(equipamento);
        }

        // GET: Equipamentos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamento
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
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var equipamento = await _context.Equipamento.FindAsync(id);
            _context.Equipamento.Remove(equipamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipamentoExists(string id)
        {
            return _context.Equipamento.Any(e => e.EquipamentoID == id);
        }
    }
}
