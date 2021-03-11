using System;
using System.Collections.Generic;

#nullable disable

namespace DesafioFPF.WebApp.Banco.Entities
{
    public partial class Rule
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
