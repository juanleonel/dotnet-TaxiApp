using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiApp.Web.Models
{
    public class TarifaViewModel
    {
        public Guid Id { get; set; }
        public DateTime FechaAlta { get; set; }
        public Guid UsuarioAltaID { get; set; }

        public DateTime? FechaMod { get; set; }
        public Guid? UsuarioModID { get; set; }

        public DateTime? FechaBaja { get; set; }
        public Guid? UsuarioBajaID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La matricula debe ser un minimo de 50 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "{0} is required")]      
        public decimal Precio { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }

        public bool Baja { get; set; }

        public string lngLat
        {
            get
            {
                return string.Concat(this.Longitud, ",", this.Latitud);
            }
        }
    }
}
