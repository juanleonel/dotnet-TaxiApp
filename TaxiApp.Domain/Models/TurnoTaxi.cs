using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiApp.Domain.Models
{
    [Table("TurnoTaxi")]
    public class TurnoTaxi
    {
        [ExplicitKey]
        public Guid ID { get; set; }
        public Guid TaxiID { get; set; }
        public Guid ChoferID { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }

        [Write(false)]
        [Computed]
        public bool FinDia { get; set; }
    }
}
