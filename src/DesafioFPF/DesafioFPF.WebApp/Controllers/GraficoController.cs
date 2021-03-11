using DesafioFPF.WebApp.Banco.Entities;
using DesafioFPF.WebApp.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Controllers
{
    public class GraficoController : Controller
    {
        IGraficoService GraficoService;

        public IActionResult Index()
        {
            IEnumerable<Employee> depto = GraficoService.GetGrafico();

            return View(depto);
        }
    }
}
