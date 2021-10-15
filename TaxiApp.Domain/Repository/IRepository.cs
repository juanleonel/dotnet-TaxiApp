using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TaxiApp.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetByID(Guid ID);
        //TEntity Create(TEntity entity);
        long Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(Guid ID);


        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindAllById(Expression<Func<TEntity, bool>> criteria);
        TEntity FindById(Expression<Func<TEntity, bool>> criteria);
        //TEntity Create(TEntity entity);
        //TEntity Update(TEntity entity);
        bool DeleteAsync(TEntity entity);
    }
}
