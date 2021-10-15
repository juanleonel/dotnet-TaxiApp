using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiApp.Domain.Models.EntityBase
{
    
    public class Entity
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public DateTime FechaAlta { get; set; }
        public Guid UsuarioAltaID { get; set; }

        public DateTime? FechaMod { get; set; }
        public Guid? UsuarioModID { get; set; }
     
        public DateTime? FechaBaja { get; set; }
        public Guid? UsuarioBajaID { get; set; }

        [Write(false)]
        [Computed]
        public bool Baja { get; set; }

    }
}
