using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiApp.Domain.Models
{
    [Table("Taxi")]
    public class Taxi: EntityBase.Entity
    { 
        public string Matricula { get; set; }
        public string Placa { get; set; }
        public string NumeroEconomico { get; set; }     
        
    }
}
