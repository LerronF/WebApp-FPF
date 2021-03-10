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

        public IActionResult Index()
        {
            IEnumerable<Departamento> depto = departamentoService.GetAllDepartamento();

            return View(depto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Departamento depto)
        {
            departamentoService.AddDepartamento(depto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Departamento depto = departamentoService.GetDepartamentoById(id);
            return View(depto);
        }

        [HttpPost]
        public ActionResult Edit(Departamento depto)
        {
            departamentoService.EditDepartamento(depto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Departamento depto = departamentoService.GetDepartamentoById(id);
            return View(depto);
        }

        [HttpPost]
        public ActionResult Delete(Departamento depto)
        {
            departamentoService.DeleteDepartamento(depto);
            return RedirectToAction(nameof(Index));
        }
    }
}
