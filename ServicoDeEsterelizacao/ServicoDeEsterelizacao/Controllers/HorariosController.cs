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
    public class HorariosController : Controller
    {
        private readonly MaterialDbContext _context;
        private const int PAGE_SIZE = 5;

        public HorariosController(MaterialDbContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index(HorarioViewList  model = null, int page = 1)
        {
            string Horario = null;

            if (model != null)
            {
                Horario = model.CurrentColaborador;
            }

            var horario = _context.Horario
                .Where(p => Horario == null || p.Colaborador.Nome.Contains(Horario));

            int numProducts = await horario.CountAsync();

            if (page > (numProducts / PAGE_SIZE) + 1)
            {
                page = 1;
            }
            var TipoList = await horario
                    .OrderBy(p => p.ColaboradorId)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();

            return View(
                new HorarioViewList
                {
                    Horario = TipoList,
                    Pagination = new PagingViewModel
                    {
                        CurrentPage = page,
                        PageSize = PAGE_SIZE,
                        Totaltems = numProducts
                    },
                    CurrentColaborador = Horario
                }
            );
        }

  /*      // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var materialDbContext = _context.HorarioColaboradores.Include(h => h.Colaborador).Include(h => h.Posto).Include(h => h.Turno);
            return View(await materialDbContext.ToListAsync());
        }
*/
        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.HorarioColaboradores
                .Include(h => h.Colaborador)
                .Include(h => h.Posto)
                .Include(h => h.Turno)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Cc");
            ViewData["PostoId"] = new SelectList(_context.Posto, "PostoId", "Nome");
            ViewData["TurnoId"] = new SelectList(_context.Turno, "TurnoId", "Nome");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HorarioID,DataInicioManha,DataFimManha,DataInicioTarde,DataFimTarde,TurnoId,PostoId,ColaboradorId")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Cc", horario.ColaboradorId);
            ViewData["PostoId"] = new SelectList(_context.Posto, "PostoId", "Nome", horario.PostoId);
            ViewData["TurnoId"] = new SelectList(_context.Turno, "TurnoId", "Nome", horario.TurnoId);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.HorarioColaboradores.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Cc", horario.ColaboradorId);
            ViewData["PostoId"] = new SelectList(_context.Posto, "PostoId", "Nome", horario.PostoId);
            ViewData["TurnoId"] = new SelectList(_context.Turno, "TurnoId", "Nome", horario.TurnoId);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HorarioID,DataInicioManha,DataFimManha,DataInicioTarde,DataFimTarde,TurnoId,PostoId,ColaboradorId")] Horario horario)
        {
            if (id != horario.HorarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.HorarioID))
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "Cc", horario.ColaboradorId);
            ViewData["PostoId"] = new SelectList(_context.Posto, "PostoId", "Nome", horario.PostoId);
            ViewData["TurnoId"] = new SelectList(_context.Turno, "TurnoId", "Nome", horario.TurnoId);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.HorarioColaboradores
                .Include(h => h.Colaborador)
                .Include(h => h.Posto)
                .Include(h => h.Turno)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.HorarioColaboradores.FindAsync(id);
            _context.HorarioColaboradores.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
            return _context.HorarioColaboradores.Any(e => e.HorarioID == id);
        }
        // GET: HorarioColaboradoress/GerarHorario
        public IActionResult GerarHorario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GerarHorario(GerarHorario gerarHorario)
        {
            if (ModelState.IsValid)
            {
                DateTime dataIn = gerarHorario.DataInicioSemana;
                GerarHorarios(_context, dataIn);
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Index));
        }

        /**Funções**/
        private void GerarHorarioColaboradoresTest(MaterialDbContext db, DateTime dia)
        {
            DateTime segunda;
            DateTime sexta;

            if (dia.DayOfWeek == DayOfWeek.Monday)
            {
                segunda = dia.Date;
                sexta = dia.Date.AddDays(5);
            }
            else
                return;

            int[] colaboradores = IdColaboradores();

            int colab = 0;

            //Lista de colaboradores
            List<int> listaColaboradores = new List<int>(colaboradores);

            int numeroColaboradores = listaColaboradores.Count();
            int controlo = 1;
            string turno;

            for (int i = 0; i <= numeroColaboradores - 1; i++)
            {
                DateTime j = segunda;
                while (!j.Equals(sexta))
                {
                    if (controlo == 1)
                    {
                        turno = "Primeiro";
                        colab = listaColaboradores[i];
                        Turno IdTurno = _context.Turno.SingleOrDefault(t => t.Nome.Equals(turno));
                        Colaborador IdColaborador = _context.Colaborador.SingleOrDefault(f => f.ColaboradorId == colab);

                        InserirDadosNoHorario(db, j.AddHours(8), j.AddHours(12), j.AddHours(13), j.AddHours(15), IdTurno, IdColaborador);
                    }
                    else if (controlo == 2)
                    {
                        turno = "Segundo";
                        colab = listaColaboradores[i];
                        Turno IdTurno = _context.Turno.SingleOrDefault(t => t.Nome.Equals(turno));
                        Colaborador IdTecnico = _context.Colaborador.SingleOrDefault(f => f.ColaboradorId == colab);

                        InserirDadosNoHorario(db, j.AddHours(11), j.AddHours(14), j.AddHours(15), j.AddHours(19), IdTurno, IdTecnico);
                    }
                    else if (controlo == 3)
                    {
                        turno = "Terceiro";
                        colab = listaColaboradores[i];
                        Turno IdTurno = _context.Turno.SingleOrDefault(t => t.Nome.Equals(turno));
                        Colaborador IdTecnico = _context.Colaborador.SingleOrDefault(f => f.ColaboradorId == colab);

                        InserirDadosNoHorario(db, j.AddHours(14), j.AddHours(19), j.AddHours(20), j.AddHours(22), IdTurno, IdTecnico);
                    }
                    j = j.AddDays(1);
                }
                controlo++;
                if (controlo > 3)
                {
                    controlo = 1;
                }
            }
        }

        private void GerarHorarios(MaterialDbContext db, DateTime dia)
        {
            DateTime segunda;
            DateTime sexta;
            string turno;

            if (dia.DayOfWeek == DayOfWeek.Monday)
            {
                segunda = dia.Date;
                sexta = dia.Date.AddDays(5);
            }
            else
                return;

            int[] tecnicos = IdColaboradores();
            int controlo = 1;
            int colab = 0;

            //Lista de Tecnicos
            List<int> listaTecnicos = new List<int>(tecnicos);

            int numeroTecnicos = listaTecnicos.Count();

            for (DateTime i = segunda; i <= sexta; i = i.AddDays(1))
            {
                for (int j = 0; j <= numeroTecnicos - 1; j++)
                {
                    if (controlo == 1)
                    {
                        turno = "Primeiro";
                        colab = listaTecnicos[j];
                        Turno IdTurno = _context.Turno.SingleOrDefault(t => t.Nome.Equals(turno));
                        Colaborador IdColaborador = _context.Colaborador.SingleOrDefault(f => f.ColaboradorId == colab);

                        InserirDadosNoHorario(db, i.AddHours(8), i.AddHours(12), i.AddHours(13), i.AddHours(15), IdTurno, IdColaborador);
                    }
                    else if (controlo == 2)
                    {
                        turno = "Segundo";
                        colab = listaTecnicos[j];
                        Turno IdTurno = _context.Turno.SingleOrDefault(t => t.Nome.Equals(turno));
                        Colaborador IdColaborador = _context.Colaborador.SingleOrDefault(f => f.ColaboradorId == colab);

                        InserirDadosNoHorario(db, i.AddHours(11), i.AddHours(14), i.AddHours(15), i.AddHours(19), IdTurno, IdColaborador);
                    }
                    else if (controlo == 3)
                    {
                        turno = "Terceiro";
                        colab = listaTecnicos[j];
                        Turno IdTurno = _context.Turno.SingleOrDefault(t => t.Nome.Equals(turno));
                        Colaborador IdColaborador = _context.Colaborador.SingleOrDefault(f => f.ColaboradorId == colab);

                        InserirDadosNoHorario(db, i.AddHours(14), i.AddHours(19), i.AddHours(20), i.AddHours(22), IdTurno, IdColaborador);
                    }
                    controlo++;
                    if (controlo > 3)
                    {
                        controlo = 1;
                    }
                }
            }
        }


        private int[] IdColaboradores()
        {
            var colaboradores = from t in _context.Colaborador
                                select t.ColaboradorId;

            int[] arrayIdColaboradores = colaboradores.ToArray();

            return arrayIdColaboradores;
        }

        private void InserirDadosNoHorario(MaterialDbContext db, DateTime datainiciomanha, DateTime datafimmanha, DateTime datainiciotarde, DateTime datafimtarde, Turno turnoId, Colaborador colaboradorId)
        {
            db.HorarioColaboradores.Add(
                new Horario { DataInicioManha = datainiciomanha, DataFimManha = datafimmanha, DataInicioTarde = datainiciotarde, DataFimTarde = datafimtarde, TurnoId = turnoId.TurnoId, ColaboradorId = colaboradorId.ColaboradorId }
            );

            db.SaveChanges();
        }

    }
}