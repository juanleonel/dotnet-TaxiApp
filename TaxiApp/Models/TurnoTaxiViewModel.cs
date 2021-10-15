using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiApp.Web.Models
{
    public class TurnoTaxiViewModel
    {       
        public Guid ID { get; set; }
        public Guid TaxiID { get; set; }
        public Guid ChoferID { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public bool FinDia { get; set; }
    }
}
