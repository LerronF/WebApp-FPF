using DesafioFPF.WebApp.Banco.Context;
using DesafioFPF.WebApp.Banco.Entities;
using DesafioFPF.WebApp.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly string _connectionString;
        public FuncionarioService(IConfiguration _configuratio)
        {
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
        }

        public IEnumerable<Employee> GetAllFuncionario()
        {
            FPFContext contexto = new FPFContext();
            return contexto.Employees;
        }

        public Employee GetFuncionarioById(int deptoId)
        {
            FPFContext contexto = new FPFContext();
            return contexto.Employees.Where(o => o.Id == deptoId).FirstOrDefault();
        }

        public void AddFuncionario(Employee depto)
        {
            FPFContext contexto = new FPFContext();

            var cont = GetAllFuncionario().Count();

            depto.Id = cont + 1;
            depto.CreatedAt = DateTime.Now;
            depto.ModifiedAt = DateTime.MinValue;
            depto.Salary = Convert.ToInt32(depto.Salary);

            contexto.Employees.Add(depto);
            contexto.SaveChanges();
        }

        public void EditFuncionario(Employee depto)
        {
            FPFContext contexto = new FPFContext();
            depto.ModifiedAt = DateTime.Now;
            depto.CreatedAt = depto.CreatedAt;
            contexto.Entry(depto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void DeleteFuncionario(Employee depto)
        {
            FPFContext contexto = new FPFContext();
            contexto.Entry(depto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.Employees.Remove(depto);
            contexto.SaveChanges();
        }
    }
}
