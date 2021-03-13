using DesafioFPF.WebApp.Banco.Entities;
using DesafioFPF.WebApp.Interface;
using DesafioFPF.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Controllers
{
    public class DepartamentoController : Controller
    {
        IDepartamentoService departamentoService;

        public DepartamentoController(IDepartamentoService _departamentoService)
        {
            departamentoService = _departamentoService;
        }

        public ViewResult Index(string searchString)
        {
            IEnumerable<Rule> depto = departamentoService.GetAllDepartamento();

            if (!String.IsNullOrEmpty(searchString))
            {
                depto = depto.Where(o => o.Name.ToUpper().Contains(searchString.ToUpper()));
            } 

            return View(depto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rule depto)
        {
            departamentoService.AddDepartamento(depto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Rule depto = departamentoService.GetDepartamentoById(id);
            return View(depto);
        }

        [HttpPost]
        public ActionResult Edit(Rule depto)
        {
            departamentoService.EditDepartamento(depto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Rule depto = departamentoService.GetDepartamentoById(id);
            return View(depto);
        }

        [HttpPost]
        public ActionResult Delete(Rule depto)
        {
            departamentoService.DeleteDepartamento(depto);
            return RedirectToAction(nameof(Index));
        }
    }
}
