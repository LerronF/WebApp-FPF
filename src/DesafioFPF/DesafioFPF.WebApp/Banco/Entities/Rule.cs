using System;
using System.Collections.Generic;

#nullable disable

namespace DesafioFPF.WebApp.Banco.Entities
{
    public partial class Rule
    {
        public Rule()
        {
            Employees = new HashSet<Employee>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
