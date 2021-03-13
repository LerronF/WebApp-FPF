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
        IDepartamentoService departamentoService;

        public FuncionarioController(IFuncionarioService _FuncionarioService, IDepartamentoService _departamentoService)
        {
            FuncionarioService = _FuncionarioService;
            departamentoService = _departamentoService;
        }

        public ViewResult Index(string searchString)
        {
            IEnumerable<Employee> depto = FuncionarioService.GetAllFuncionario();

            if (!String.IsNullOrEmpty(searchString))
            {
                depto = depto.Where(o => o.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(depto);
        }

        public IActionResult Create()
        {
            Employee func = new Employee();
            CarregarListasComplementares(func);
            return View(func);
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
            CarregarListasComplementares(depto);
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

        private void CarregarListasComplementares(Employee itemViewModel)
        {
            List<Rule> depto = departamentoService.CarregaDepartamento();

            itemViewModel.Departamento = depto;
        }
    }
}
