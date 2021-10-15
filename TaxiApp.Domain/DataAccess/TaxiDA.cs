using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TaxiApp.Domain.Infrestructura;
using TaxiApp.Domain.Interfaces;
using TaxiApp.Domain.Models;

namespace TaxiApp.Domain.DataAccess
{
    public class TaxiDA : ITaxi 
    {

        private readonly IConnectionFactory _connectionFactory;

        public TaxiDA(IConnectionFactory connectionFactory)
        {           
            _connectionFactory = connectionFactory;
        }

        #region CRUD
        public void Create(Taxi entity)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();
                var result = db.Insert(entity);               
            }
        }

        public void Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Taxi entity)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();
                return db.Delete<Taxi>(entity);
            }
        }

        public IList<Taxi> GetAll()
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();
                return db.GetAll<Taxi>().ToList();
            }
        }

        public Taxi GetByID(Guid ID)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();
                return db.Get<Taxi>(ID);
            }
        }

        public bool Update(Taxi entity)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();                 
                return db.Update<Taxi>(entity);
            }
        }

        #endregion

        public bool Disable(Guid ID)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();
                var taxi = this.GetByID(ID);
                if (taxi != null)
                {
                    taxi.Baja = true;
                    taxi.FechaBaja = DateTime.Now;
                    taxi.UsuarioBajaID = Guid.NewGuid();

                    return db.Update<Taxi>(taxi);
                }

                return false;
            }
        }
    }
}
