using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaxiApp.Domain.Infrestructura;
using TaxiApp.Domain.Interfaces;
using TaxiApp.Domain.Models;

namespace TaxiApp.Domain.DataAccess
{
    public class TarifaDA : ITarifa
    {
        private readonly IConnectionFactory _connectionFactory;

        public TarifaDA(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Create(Tarifa entity)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {                
                db.Insert(entity);
            }
        }

        public void Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Tarifa entity)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();
                return db.Delete<Tarifa>(entity);
            }
        }

        public IList<Tarifa> GetAll()
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                return db.GetAll<Tarifa>().ToList();
            }
        }

        public Tarifa GetByID(Guid ID)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                return db.Get<Tarifa>(ID);
            }
        }

        public bool Update(Tarifa entity)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                return db.Update<Tarifa>(entity);
            }
        }
    }
}
