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
    public class InfoModelsController : Controller
    {
        private readonly ServicoDeEsterelizacaoContext _context;

        public InfoModelsController(ServicoDeEsterelizacaoContext context)
        {
            _context = context;
        }

        // GET: InfoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.InfoModel.ToListAsync());
        }

        // GET: InfoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoModel = await _context.InfoModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (infoModel == null)
            {
                return NotFound();
            }

            return View(infoModel);
        }

        // GET: InfoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialcsId,Nome,password,Funcao")] InfoModel infoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoModel);
        }

        // GET: InfoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoModel = await _context.InfoModel.FindAsync(id);
            if (infoModel == null)
            {
                return NotFound();
            }
            return View(infoModel);
        }

        // POST: InfoModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialcsId,Nome,password,Funcao")] InfoModel infoModel)
        {
            if (id != infoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoModelExists(infoModel.ID))
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
            return View(infoModel);
        }

        // GET: InfoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoModel = await _context.InfoModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (infoModel == null)
            {
                return NotFound();
            }

            return View(infoModel);
        }

        // POST: InfoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoModel = await _context.InfoModel.FindAsync(id);
            _context.InfoModel.Remove(infoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoModelExists(int id)
        {
            return _context.InfoModel.Any(e => e.ID == id);
        }
    }
}
