
using DesafioFPF.WebApp.Banco.Context;
using DesafioFPF.WebApp.Banco.Entities;
using DesafioFPF.WebApp.Interface;
using DesafioFPF.WebApp.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly string _connectionString;
        public DepartamentoService(IConfiguration _configuratio)
        {
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
        }

        public IEnumerable<Rule> GetAllDepartamento()
        {
            FPFContext contexto = new FPFContext();
            return contexto.Rules;
        }

        public Rule GetDepartamentoById(int deptoId)
        {
            FPFContext contexto = new FPFContext();
            return contexto.Rules.Where(o => o.Id == deptoId).FirstOrDefault();
        }

        public void AddDepartamento(Rule depto)
        {
            FPFContext contexto = new FPFContext();

            var cont = GetAllDepartamento().Count();

            depto.Id = cont + 1;
            depto.CreatedAt = DateTime.Now;
            depto.ModifiedAt = DateTime.MinValue;

            contexto.Rules.Add(depto);
            contexto.SaveChanges();
        }

        public void EditDepartamento(Rule depto)
        {
            FPFContext contexto = new FPFContext();
            depto.ModifiedAt = DateTime.Now;
            contexto.Entry(depto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void DeleteDepartamento(Rule depto)
        {
            FPFContext contexto = new FPFContext();
            contexto.Entry(depto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.Rules.Remove(depto);
            contexto.SaveChanges();
        }
    }
}
