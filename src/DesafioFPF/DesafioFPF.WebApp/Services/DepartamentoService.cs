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

        public IEnumerable<Departamento> GetAllDepartamento()
        {
            List<Departamento> deptoList = new List<Departamento>();

            using(OracleConnection con = new OracleConnection(_connectionString))
            {
                using(OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "Select ID, NAME, ACTIVE From RULE";
                        OracleDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Departamento depto = new Departamento
                            {
                                ID = Convert.ToInt32(rdr["ID"]),
                                NAME = rdr["NAME"].ToString(),
                                ACTIVE = rdr["ACTIVE"].ToString()
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

        public Departamento GetDepartamentoById(int deptoId)
        {
            Departamento depto = new Departamento();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select ID, NAME, ACTIVE from rule where id =" + deptoId + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        depto.ID = Convert.ToInt32(rdr["ID"]);
                        depto.NAME = rdr["NAME"].ToString();
                        depto.ACTIVE = rdr["ACTIVE"].ToString();   
                    }
                }
            }
            return depto;
        }

        public void AddDepartamento(Departamento depto)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "Insert into RULE(ID, NAME, ACTIVE,CREATED_AT, MODIFIED_AT )" +
                                          "Values(" + depto.ID + ",'" + depto.NAME + "','" + depto.ACTIVE + "','" + DateTime.Now + "','" + DateTime.MinValue + "')";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditDepartamento(Departamento depto)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "Update RULE set NAME='" + depto.NAME + "', ACTIVE='" + depto.ACTIVE + "', MODIFIED_AT= '" + DateTime.Now + "' where ID=" + depto.ID;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteDepartamento(Departamento depto)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "Delete from RULE where ID=" + depto.ID;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
