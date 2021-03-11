using System;
using System.Collections.Generic;

#nullable disable

namespace DesafioFPF.WebApp.Banco.Entities
{
    public partial class Employee
    {
        public decimal Id { get; set; }
        public decimal IdRule { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Gender { get; set; }
        public string Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Rule IdRuleNavigation { get; set; }
    }
}
