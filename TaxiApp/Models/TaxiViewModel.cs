using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiApp.Web.Models
{
    public class TaxiViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La matricula debe ser un maximo de 50 caracteres")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La placa debe ser un maximo de 50 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El numero economico debe ser un maximo de 50 caracteres")]
        public string NumeroEconomico { get; set; }
        public DateTime FechaAlta { get; set; }
        public Guid UsuarioAltaID { get; set; }
        public DateTime? FechaMod { get; set; }
        public Guid? UsuarioModID { get; set; }
        public DateTime? FechaBaja { get; set; }
        public Guid? UsuarioBajaID { get; set; } 
        public bool Baja { get; set; }
    }
}
