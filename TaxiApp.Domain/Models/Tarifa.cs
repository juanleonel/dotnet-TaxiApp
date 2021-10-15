using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TaxiApp.Domain.Models.EntityBase;

namespace TaxiApp.Domain.Models
{
    [Table("Tarifa")]
    public class Tarifa: Entity
    {
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        
        [Computed]
        [Write(false)]
        public string lngLat { 
            get { 
                return string.Concat(this.Longitud, ",", this.Latitud); 
            } 
        }
    }
}
