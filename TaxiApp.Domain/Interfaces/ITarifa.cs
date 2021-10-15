using System;
using System.Collections.Generic;
using System.Text;
using TaxiApp.Domain.Models;

namespace TaxiApp.Domain.Interfaces
{
    public interface ITarifa
    {
        void Create(Tarifa entity);
        void Delete(Guid ID);
        bool Delete(Tarifa entity);
        IList<Tarifa> GetAll();
        Tarifa GetByID(Guid ID);
        bool Update(Tarifa entity);
        
    }
}
