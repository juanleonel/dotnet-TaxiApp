using Dapper;
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
    public class ChoferDA : IChofer
    {
        private readonly IConnectionFactory _connectionFactory;

        public ChoferDA(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region CRUD
        public void Create(Chofer entity)
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

        public bool Delete(Chofer entity)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();
                return db.Delete<Chofer>(entity);
            }
        }

        public bool Disable(Guid ID)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();
                var chofer = this.GetByID(ID);
                if (chofer != null)
                {
                    chofer.Baja = true;
                    chofer.FechaBaja = DateTime.Now;
                    chofer.UsuarioBajaID = Guid.NewGuid();

                    return db.Update<Chofer>(chofer);
                }

                return false;
            }
        }

        public IList<Chofer> GetAll()
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            { 
                return db.GetAll<Chofer>().ToList();
            }
        }

        public Chofer GetByID(Guid ID)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                //db.Open();
                return db.Get<Chofer>(ID);
            }
        }

        public bool Update(Chofer entity)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {                
                return db.Update<Chofer>(entity);
            }
        }

        #endregion

        public TurnoTaxi IniciaTurno(Guid ChoferID, Guid TaxiID, DateTime FechaEntrada) {

            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                const string sql = @"[dbo].[spInsTurnoTaxi]";

                var result = db.Query<TurnoTaxi>(sql, new { @ChoferID, @TaxiID, @FechaEntrada }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return result;
            }
            
        }

        public TurnoTaxi GetTurnoByID(Guid ID)
        {
            using (IDbConnection db = _connectionFactory.GetConnection)
            {
                return db.Get<TurnoTaxi>(ID);
            }
        }
    }
}
