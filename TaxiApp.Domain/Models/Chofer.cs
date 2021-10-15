using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TaxiApp.Domain.Models.EntityBase;

namespace TaxiApp.Domain.Models
{
    [Table("Chofer")]
    public class Chofer: Entity
    {
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string  SegundoApellido { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
    }
}
