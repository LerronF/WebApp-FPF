using DesafioFPF.WebApp.Banco.Entities;
using DesafioFPF.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Interface
{
    public interface IDepartamentoService
    {
        IEnumerable<Rule> GetAllDepartamento();
        Rule GetDepartamentoById(int deptoId);
        void AddDepartamento(Rule depto);
        void EditDepartamento(Rule depto);
        void DeleteDepartamento(Rule depto);

        List<Rule> CarregaDepartamento();
    }
}
