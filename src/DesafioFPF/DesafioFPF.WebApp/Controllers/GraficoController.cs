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
        IGraficoService graficoService;

        public GraficoController(IGraficoService _graficoService)
        {
            graficoService = _graficoService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Data()
        {
            List<Employee> depto = graficoService.GetGrafico();

            List<object> obj = new List<object>();
            try
            {                
                foreach (var item in depto)
                {
                    obj.Add(new
                    {
                        Nome = item.Name,
                        Salario = item.Salary
                    });
                }

                ViewBag.Listagem = depto;
            }
            catch (Exception ex)
            {
            }

            return Json(obj);
        }
    }
}
