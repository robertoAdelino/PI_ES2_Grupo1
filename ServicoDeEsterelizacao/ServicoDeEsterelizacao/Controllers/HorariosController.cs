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
        public async Task<IActionResult> Index(HorarioViewList model = null, int page = 1, string order = null)
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

            IEnumerable<Horario> TipoList;

            if (order == "ID")
            {
                TipoList = await horario
                    .Include(p=>p.Colaborador)
                    .Include(p=>p.Posto)
                    .Include(p=>p.Turno)
                    .OrderBy(p => p.HorarioID)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if (order == "Colaborador")
            {
                TipoList = await horario
                    .Include(p => p.Colaborador)
                    .Include(p => p.Posto)
                    .Include(p => p.Turno)
                    .OrderBy(p => p.Colaborador.Nome)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if (order == "Posto")
            {
                TipoList = await horario
                    .Include(p => p.Colaborador)
                    .Include(p => p.Posto)
                    .Include(p => p.Turno)
                    .OrderBy(p => p.Posto.Nome)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if (order == "Turno")
            {
                TipoList = await horario
                    .Include(p => p.Colaborador)
                    .Include(p => p.Posto)
                    .Include(p => p.Turno)
                    .OrderBy(p => p.Turno.Nome)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if (order == "DataInicioTurno")
            {
                TipoList = await horario
                    .Include(p => p.Colaborador)
                    .Include(p => p.Posto)
                    .Include(p => p.Turno)
                    .OrderBy(p => p.DataInicioTurno)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if (order == "DataFimTurno")
            {
                TipoList = await horario
                    .Include(p => p.Colaborador)
                    .Include(p => p.Posto)
                    .Include(p => p.Turno)
                    .OrderBy(p => p.DataFimTurno)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else if(order == "Duracao")
            {
                TipoList = await horario
                    .Include(p => p.Colaborador)
                    .Include(p => p.Posto)
                    .Include(p => p.Turno)
                    .OrderBy(p => p.Duracao)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            else
            {
                TipoList = await horario
                    .Include(p => p.Colaborador)
                    .Include(p => p.Posto)
                    .Include(p => p.Turno)
                    .OrderBy(p => p.HorarioID)
                    .Skip(PAGE_SIZE * (page - 1))
                    .Take(PAGE_SIZE)
                    .ToListAsync();
            }
            /*TipoList = await colaborador
                 .OrderBy(p => p.Nome)
                 .Skip(PAGE_SIZE * (page - 1))
                 .Take(PAGE_SIZE)
                 .ToListAsync();*/

            return View(
                new HorarioViewList
                {
                    Horario = TipoList,
                    Pagination = new PagingViewModel
                    {
                        CurrentPage = page,
                        PageSize = PAGE_SIZE,
                        Totaltems = numProducts,
                        Order = order
                    },
                    CurrentColaborador = Horario
                }
            );
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.GerarHorarios
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
        public async Task<IActionResult> Create([Bind("HorarioID,DataInicioTurno,Duracao,DataFimTurno,TurnoId,PostoId,ColaboradorId")] Horario horario)
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

            var horario = await _context.GerarHorarios.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("HorarioID,DataInicioTurno,Duracao,DataFimTurno,TurnoId,PostoId,ColaboradorId")] Horario horario)
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

            var horario = await _context.GerarHorarios
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
            var horario = await _context.GerarHorarios.FindAsync(id);
            _context.GerarHorarios.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
            return _context.GerarHorarios.Any(e => e.HorarioID == id);
        }


        // GET: GERAR HORARIO COLABORADORES



        public IActionResult GerarHorario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GerarHorario( GerarHorario gerarHorarioColaboradores)
        {
            //Variáveis
            int numPessoasT1 = gerarHorarioColaboradores.NPessoasT1;
            int numPessoasT2 = gerarHorarioColaboradores.NPessoasT2;

            DateTime dataInicio = gerarHorarioColaboradores.DataInicio;

            int ano = dataInicio.Year;
            int mes = dataInicio.Month;
            int dia = dataInicio.Day;

            /**********Validações***********/

            //Validar se Data de Início de Semana é uma segunda-feira
            if (ValidateDayOfTheWeek(dataInicio) == true)
            {
                
                ModelState.AddModelError("DataInicioSemana", "Tem de selecionar uma data correspondente a uma segunda-feira e/ou igual ou superior à data atual");
            }

            //???????????
            if (NumColabsTurno(numPessoasT1, numPessoasT2) == true)
            {
                //?????????????
                ModelState.AddModelError("NumeroPessoasTurno3", "Não tem médicos suficientes para todos os turnos. Por favor, verifique os campos e tente novamente");
            }

            if (ModelState.IsValid)
            {
                if (!ValidateDayOfTheWeek(dataInicio) || !NumColabsTurno(numPessoasT1, numPessoasT2))
                {

                    GenerateHorario(_context, numPessoasT1, numPessoasT2, ano, mes, dia);
                    TempData["Success"] = "Horário gerado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(gerarHorarioColaboradores);
        }


        private void GenerateHorario(MaterialDbContext db, int numT1, int numT2, int ano, int mes, int dia)
        {

            int numPessoasT1 = 1;
            int numPessoasT2 = 1;

            int segunda = 2;
            int domingo = 6;

            int[] colaboradores = ColabIds();
            int[] postos = PostosIds();

            int colabT1 = 0;
            int colabT2 = 0;
            int postoT1 = 0;
            int postoT2 = 0;


            List<int> listaColabs;
            List<int> listaPosto;

            Random rnd = new Random();

            DateTime data;

            for (int i = segunda; i <= domingo; i++)
            {
                listaPosto = new List<int>(postos);

                listaColabs = new List<int>(colaboradores);

                for (int j = 0; j < numPessoasT1; j++) 
                {
                    string turno = "MANHÃ";
                    int duracao = 8;


                    colabT1 = listaColabs[rnd.Next(0, listaColabs.Count())];

                    postoT1=listaPosto[rnd.Next(0, listaPosto.Count())];

                    data = new DateTime(ano, mes, dia, 9, 0, 0);

                    Turno turnoId = _context.Turno.SingleOrDefault(t => t.Nome.Equals(turno));
                    Colaborador colaboradorT1 = _context.Colaborador.SingleOrDefault(m => m.ColaboradorId == colabT1);
                    Posto postosT1 = _context.Posto.SingleOrDefault(m => m.PostoId == postoT1);


                    InsertDataIntoHorario(db, data.AddDays(i - 2), duracao, data.AddDays(i - 2).AddHours(duracao), turnoId, colaboradorT1,postosT1);

 

                    listaColabs.Remove(colabT1);
                }

                for (int k = 0; k < numPessoasT2; k++)
                {
                    string turno = "TARDE";
                    int duracao = 8;

                    colabT2 = listaColabs[rnd.Next(0, listaColabs.Count())];
                    data = new DateTime(ano, mes, dia, 16, 0, 0);
                    postoT2 = listaPosto[rnd.Next(0, listaPosto.Count())];

                    Turno turnoId = _context.Turno.SingleOrDefault(t => t.Nome.Equals(turno));
                    Colaborador colaboradorT2 = _context.Colaborador.SingleOrDefault(m => m.ColaboradorId == colabT2);
                    Posto postosT2 = _context.Posto.SingleOrDefault(m => m.PostoId == postoT2);


                    InsertDataIntoHorario(db, data.AddDays(i - 2), duracao, data.AddDays(i - 2).AddHours(duracao), turnoId, colaboradorT2,postosT2);


                    listaColabs.Remove(colabT2);
                }

            }
        }


        private void InsertDataIntoHorario(MaterialDbContext db, DateTime dataInicioTurno, int duracao, DateTime dataFimTurno, Turno turnoId, Colaborador colaboradorID,Posto postoID)
        {
            db.GerarHorarios.Add(
                new Horario { DataInicioTurno = dataInicioTurno, Duracao = duracao, DataFimTurno = dataInicioTurno.AddHours(duracao), TurnoId = turnoId.TurnoId, ColaboradorId = colaboradorID.ColaboradorId, PostoId=postoID.PostoId}
            );

            db.SaveChanges();
        }


        private bool ValidateDayOfTheWeek(DateTime data)
        {
            bool IsInvalid = false;
            DateTime dateNow = DateTime.Now;

            int dateTimeCompare = DateTime.Compare(data, dateNow);

            if ((data.DayOfWeek != DayOfWeek.Monday) || dateTimeCompare < 0)
            {
                IsInvalid = true;
            }

            return IsInvalid;
        }


        private int[] ColabIds()
        {
            var colaboradores = from m in _context.Colaborador
                                select m.ColaboradorId;

            int[] arrIdColabs = colaboradores.ToArray();

            return arrIdColabs;
        }

        private int[] PostosIds()
        {
            var postos = from m in _context.Posto
                                select m.PostoId;

            int[] arrIdPostos = postos.ToArray();

            return arrIdPostos;
        }

        private bool NumColabsTurno(int numT1, int numT2)
        {
            bool IsInvalid = false;

            int totalColab = numT1 + numT2;

            if (ColabIds().Length <= totalColab)
            {
                IsInvalid = true;
            }

            return IsInvalid;
        }

       

    }
}

