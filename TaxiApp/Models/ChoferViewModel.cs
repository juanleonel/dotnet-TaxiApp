using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiApp.Web.Models
{
    public class ChoferViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]       
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]        
        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "el Email no es valido")]
        public string Email { get; set; }

        public IFormFile ImagenFile { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaAlta { get; set; }
        public Guid UsuarioAltaID { get; set; }

        public DateTime? FechaMod { get; set; }
        public Guid? UsuarioModID { get; set; }

        public DateTime? FechaBaja { get; set; }
        public Guid? UsuarioBajaID { get; set; }
 
        public bool Baja { get; set; }
    }
}
