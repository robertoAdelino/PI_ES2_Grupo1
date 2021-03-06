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
    public class PostosController : Controller
    {
        private readonly MaterialDbContext _context;
        private const int PAGE_SIZE = 5;
        public PostosController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Postos
        public async Task<IActionResult> Index(PostoViewList model = null, int page = 1, string order = null)
        {
            string Posto = null;

            if (model != null)
            {
                Posto = model.CurrentNome;
            }

            var posto = _context.Posto
                .Where(p => Posto == null || p.Nome.Contains(Posto));

            int numProducts = await posto.CountAsync();

            if (page > (numProducts / PAGE_SIZE) + 1)
            {
                page = 1;
            }

            IEnumerable<Posto> TipoList;

            if(order == "ID")
            {
                TipoList = await posto
                    .OrderBy(p => p.PostoId)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if (order == "Nome")
            {
                TipoList = await posto
                    .OrderBy(p => p.Nome)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            TipoList = await posto
                    .OrderBy(p => p.PostoId)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();

            return View(
                new PostoViewList
                {
                    Posto = TipoList,
                    Pagination = new PagingViewModel
                    {
                        CurrentPage = page,
                        PageSize = PAGE_SIZE,
                        Totaltems = numProducts,
                        Order = order
                    },
                    CurrentNome = Posto
                }
            );
        }

        // GET: Postos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posto = await _context.Posto
                .FirstOrDefaultAsync(m => m.PostoId == id);
            if (posto == null)
            {
                return NotFound();
            }

            return View(posto);
        }

        // GET: Postos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostoId,Nome")] Posto posto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posto);
        }

        // GET: Postos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posto = await _context.Posto.FindAsync(id);
            if (posto == null)
            {
                return NotFound();
            }
            return View(posto);
        }

        // POST: Postos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostoId,Nome")] Posto posto)
        {
            if (id != posto.PostoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostoExists(posto.PostoId))
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
            return View(posto);
        }

        // GET: Postos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posto = await _context.Posto
                .FirstOrDefaultAsync(m => m.PostoId == id);
            if (posto == null)
            {
                return NotFound();
            }

            return View(posto);
        }

        // POST: Postos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posto = await _context.Posto.FindAsync(id);
            _context.Posto.Remove(posto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostoExists(int id)
        {
            return _context.Posto.Any(e => e.PostoId == id);
        }
    }
}
