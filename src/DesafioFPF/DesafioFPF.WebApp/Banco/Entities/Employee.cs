using DesafioFPF.WebApp.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DesafioFPF.WebApp.Banco.Entities
{
    public partial class Employee
    {
        public Employee()
        {
           // Departamento = CarregaDepto("");
        }

        public decimal Id { get; set; }
        public decimal IdRule { get; set; }
        
        [NotMapped]
        public List<Rule> Departamento { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Gender { get; set; }
        public string Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Rule IdNavigation { get; set; }
    }
}
