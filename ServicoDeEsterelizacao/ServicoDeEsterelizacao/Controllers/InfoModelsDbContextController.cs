using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Data;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Controllers
{
    public class InfoModelsDbContextController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InfoModelsDbContextController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InfoModelsDbContext
        public async Task<IActionResult> Index()
        {
            return View(await _context.InfoModel.ToListAsync());
        }

        // GET: InfoModelsDbContext/Details/5
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

        // GET: InfoModelsDbContext/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoModelsDbContext/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,password,funcao,alteracao")] InfoModel infoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoModel);
        }

        // GET: InfoModelsDbContext/Edit/5
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

        // POST: InfoModelsDbContext/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,password,funcao,alteracao")] InfoModel infoModel)
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

        // GET: InfoModelsDbContext/Delete/5
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

        // POST: InfoModelsDbContext/Delete/5
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
