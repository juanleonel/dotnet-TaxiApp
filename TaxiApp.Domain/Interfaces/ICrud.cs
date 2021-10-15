using System;
using System.Collections.Generic;
using System.Text;
using TaxiApp.Domain.Models.EntityBase;

namespace TaxiApp.Domain.Interfaces
{
    public interface ICrud<T> where T : class
    {
        void Create(T entity);
        IList<T> GetAll();
        T GetByID(Guid ID);
        void Update(T entity);
        void Delete(Guid ID);
    }
}
