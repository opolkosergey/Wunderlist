using System;
using System.Linq;
using System.Linq.Expressions;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity, IEntity owner);
        void Update(TEntity entity);
        void Remove(int id);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}
