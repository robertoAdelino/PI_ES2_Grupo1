using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Data
{
    public class Trabalho_PostoController : Controller
    {
        private readonly MaterialDbContext _context;
        private const int PAGE_SIZE = 5;
        public Trabalho_PostoController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Trabalho_Posto
        public async Task<IActionResult> Index(Trabalho_PostoViewList model = null, int page = 1, string order = null)
        {
            string Tarefa = null;

            if (model != null)
            {
                Tarefa = model.CurrentNome;
            }

            var tarefa = _context.Trabalho_Posto
                .Where(p => Tarefa == null || p.Materialcs.Nome.Contains(Tarefa));

            int numProducts = await tarefa.CountAsync();

            if (page > (numProducts / PAGE_SIZE) + 1)
            {
                page = 1;
            }
            IEnumerable<Trabalho_Posto> TipoList;
            if (order == "ID")
            {
                TipoList = await tarefa
                    .Include (p=>p.Equipamento)
                    .Include(p => p.Materialcs)
                    .Include(p => p.Equipamento.Tipo)
                    .Include(p => p.Horario.Colaborador)
                    .OrderBy(p => p.Trabalho_PostoID)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if (order == "DataServico")
            {
                TipoList = await tarefa
                    .Include(p => p.Equipamento)
                    .Include(p => p.Materialcs)
                    .Include(p => p.Equipamento.Tipo)
                    .Include(p => p.Horario.Colaborador)
                    .OrderBy(p => p.DataServico)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if(order == "Material")
            {
                TipoList = await tarefa
                    .Include(p => p.Equipamento)
                    .Include(p => p.Materialcs)
                    .Include(p => p.Equipamento.Tipo)
                    .Include(p => p.Horario.Colaborador)
                    .OrderBy(p => p.MaterialcsID)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if(order == "Equipamento")
            {
                TipoList = await tarefa
                    .Include(p => p.Equipamento)
                    .Include(p => p.Materialcs)
                    .Include(p=>p.Equipamento.Tipo)
                    .Include(p => p.Horario.Colaborador)
                    .OrderBy(p => p.EquipamentoID)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if(order == "Horario")
            {
                TipoList = await tarefa
                    .Include(p => p.Equipamento)
                    .Include(p => p.Materialcs)
                    .Include(p => p.Equipamento.Tipo)
                    .Include(p => p.Horario.Colaborador)
                    .OrderBy(p => p.HorarioID)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if(order == "Estado")
            {
                TipoList = await tarefa
                    .Include(p => p.Equipamento)
                    .Include(p => p.Materialcs)
                    .Include(p => p.Equipamento.Tipo)
                    .Include(p => p.Horario.Colaborador)
                    .OrderBy(p => p.Estado)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if (order == "Colab")
            {

            
            TipoList = await tarefa
                    .Include(p =>p.Equipamento)
                    .Include(p => p.Materialcs)
                    .Include(p => p.Equipamento.Tipo)
                    .Include(p => p.Horario.Colaborador)
                    .OrderBy(p => p.Horario.Colaborador.Nome)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }else
            {
                TipoList = await tarefa
                    .Include(p => p.Equipamento)
                    .Include(p => p.Materialcs)
                    .Include(p => p.Equipamento.Tipo)
                    .Include(p => p.Horario.Colaborador)
                    .OrderBy(p => p.Trabalho_PostoID)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }

            return View(
                new Trabalho_PostoViewList
                {
                    Tarefa = TipoList,
                    Pagination = new PagingViewModel
                    {
                        CurrentPage = page,
                        PageSize = PAGE_SIZE,
                        Totaltems = numProducts
                    },
                    CurrentNome = Tarefa
                }
            );
        }

        // GET: Trabalho_Posto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho_Posto = await _context.Trabalho_Posto
                .Include(t => t.Equipamento)
                .Include(t => t.Horario)
                .Include(t => t.Materialcs)
                .FirstOrDefaultAsync(m => m.Trabalho_PostoID == id);
            if (trabalho_Posto == null)
            {
                return NotFound();
            }

            return View(trabalho_Posto);
        }

        // GET: Trabalho_Posto/Create
        public IActionResult Create()
        {
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "EquipamentoID", "EquipamentoID");
            ViewData["HorarioID"] = new SelectList(_context.Horario, "HorarioID", "HorarioID");
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome");
            return View();
        }

        // POST: Trabalho_Posto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Trabalho_PostoID,EquipamentoID,MaterialcsID,Estado,HorarioID,DataServico")] Trabalho_Posto trabalho_Posto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabalho_Posto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID", trabalho_Posto.EquipamentoID);
            ViewData["HorarioID"] = new SelectList(_context.Horario, "HorarioID", "HorarioID", trabalho_Posto.HorarioID);
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome", trabalho_Posto.MaterialcsID);
            return View(trabalho_Posto);
        }

        // GET: Trabalho_Posto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho_Posto = await _context.Trabalho_Posto.FindAsync(id);
            if (trabalho_Posto == null)
            {
                return NotFound();
            }
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID", trabalho_Posto.EquipamentoID);
            ViewData["HorarioID"] = new SelectList(_context.Horario, "HorarioID", "HorarioID", trabalho_Posto.HorarioID);
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome", trabalho_Posto.MaterialcsID);
            return View(trabalho_Posto);
        }

        // POST: Trabalho_Posto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Trabalho_PostoID,EquipamentoID,MaterialcsID,Estado,HorarioID,DataServico")] Trabalho_Posto trabalho_Posto)
        {
            if (id != trabalho_Posto.MaterialcsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabalho_Posto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Trabalho_PostoExists(trabalho_Posto.MaterialcsID))
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
            ViewData["EquipamentoID"] = new SelectList(_context.Equipamento, "TipoID", "TipoID", trabalho_Posto.EquipamentoID);
            ViewData["HorarioID"] = new SelectList(_context.Horario, "HorarioID", "HorarioID", trabalho_Posto.HorarioID);
            ViewData["MaterialcsID"] = new SelectList(_context.Materialcs, "MaterialcsId", "Nome", trabalho_Posto.MaterialcsID);
            return View(trabalho_Posto);
        }

        // GET: Trabalho_Posto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho_Posto = await _context.Trabalho_Posto
                .Include(t => t.Equipamento)
                .Include(t => t.Horario)
                .Include(t => t.Materialcs)
                .FirstOrDefaultAsync(m => m.Trabalho_PostoID == id);
            if (trabalho_Posto == null)
            {
                return NotFound();
            }

            return View(trabalho_Posto);
        }

        // POST: Trabalho_Posto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabalho_Posto = await _context.Trabalho_Posto.FindAsync(id);
            _context.Trabalho_Posto.Remove(trabalho_Posto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Trabalho_PostoExists(int id)
        {
            return _context.Trabalho_Posto.Any(e => e.MaterialcsID == id);
        }
    }
}
