using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServicoDeEsterelizacao.Controllers
{
    public class MenusController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult VHorarios()
        {
            return View();
        }
        public IActionResult GHorarios()
        {
            return View();
        }
        public IActionResult AHorarios()
        {
            return View();
        }
        public IActionResult PSemanal()
        {
            return View();
        }
        public IActionResult AAlteracao()
        {
            return View();
        }
        public IActionResult AColaborador()
        {
            return View();
        }
    }
}