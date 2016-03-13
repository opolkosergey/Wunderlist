using System;
using System.Linq;
using System.Linq.Expressions;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.API
{
    public interface IRepository<TEntity> where TEntity : IEntityModel
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TodoItemModel> GetPage(int id, int page, int pageSize);
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
        int Count(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}
