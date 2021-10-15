using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TaxiApp.Domain.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public TEntity Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindAllById(Expression<Func<TEntity, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(Expression<Func<TEntity, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetByID(Guid ID)
        {
            using (IDbConnection db = new SqlConnection(string.Empty))
            {
                return db.Query<TEntity>("select * from dbo.Taxi where baja = 1 ").FirstOrDefault();
            }
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        long IRepository<TEntity>.Create(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
