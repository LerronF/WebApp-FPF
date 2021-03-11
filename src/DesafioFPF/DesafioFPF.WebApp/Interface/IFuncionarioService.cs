using DesafioFPF.WebApp.Banco.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Interface
{
    public interface IFuncionarioService
    {
        IEnumerable<Employee> GetAllFuncionario();
        Employee GetFuncionarioById(int id);
        void AddFuncionario(Employee id);
        void EditFuncionario(Employee id);
        void DeleteFuncionario(Employee id);
    }
}
