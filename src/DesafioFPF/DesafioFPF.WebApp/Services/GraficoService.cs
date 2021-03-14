using DesafioFPF.WebApp.Banco.Entities;
using DesafioFPF.WebApp.Interface;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFPF.WebApp.Services
{
    public class GraficoService : IGraficoService
    {
        private readonly string _connectionString;
        public GraficoService(IConfiguration _configuratio)
        {
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
        }
        public List<Employee> GetGrafico()
        {
            List<Employee> deptoList = new List<Employee>();

            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT Sum(EMPLOYEE.SALARY) SALARIO, RULE.NAME DEPTO  FROM EMPLOYEE, RULE WHERE EMPLOYEE.id_rule = rule.id group by RULE.NAME";
                        OracleDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Employee depto = new Employee
                            {
                                Salary = Convert.ToInt32(rdr["SALARIO"]),
                                Name = rdr["DEPTO"].ToString(),
                            };
                            deptoList.Add(depto);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return deptoList;
        }
    }
}
