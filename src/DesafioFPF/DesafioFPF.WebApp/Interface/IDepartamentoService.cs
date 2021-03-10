using DesafioFPF.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Interface
{
    public interface IDepartamentoService
    {
        IEnumerable<Departamento> GetAllDepartamento();
        Departamento GetDepartamentoById(int deptoId);
        void AddDepartamento(Departamento depto);
        void EditDepartamento(Departamento depto);
        void DeleteDepartamento(Departamento depto);
    }
}
