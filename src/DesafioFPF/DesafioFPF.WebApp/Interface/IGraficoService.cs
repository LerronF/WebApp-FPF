using DesafioFPF.WebApp.Banco.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Interface
{
    public interface IGraficoService
    {
        IEnumerable<Employee> GetGrafico();
    }
}
