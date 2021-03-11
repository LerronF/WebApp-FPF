using DesafioFPF.WebApp.Banco.Entities;
using DesafioFPF.WebApp.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Controllers
{
    public class FuncionarioController : Controller
    {
        IFuncionarioService FuncionarioService;

        public FuncionarioController(IFuncionarioService _FuncionarioService)
        {
            FuncionarioService = _FuncionarioService;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> depto = FuncionarioService.GetAllFuncionario();

            return View(depto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee depto)
        {
            FuncionarioService.AddFuncionario(depto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Employee depto = FuncionarioService.GetFuncionarioById(id);
            return View(depto);
        }

        [HttpPost]
        public ActionResult Edit(Employee depto)
        {
            FuncionarioService.EditFuncionario(depto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Employee depto = FuncionarioService.GetFuncionarioById(id);
            return View(depto);
        }

        [HttpPost]
        public ActionResult Delete(Employee depto)
        {
            FuncionarioService.DeleteFuncionario(depto);
            return RedirectToAction(nameof(Index));
        }
    }
}
