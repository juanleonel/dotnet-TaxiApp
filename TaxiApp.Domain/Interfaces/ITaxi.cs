using System;
using System.Collections.Generic;
using System.Text;
using TaxiApp.Domain.Models;

namespace TaxiApp.Domain.Interfaces
{
    public interface ITaxi  
    {
        void Create(Taxi entity);
        void Delete(Guid ID);
        bool Delete(Taxi entity);
        bool Disable(Guid ID);
        IList<Taxi> GetAll();
        Taxi GetByID(Guid ID);
        bool Update(Taxi entity);
    }
}
