using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IEntityModel
    {
        protected readonly IDbSet<TEntity> _dbSet;

        protected BaseRepository(DbContext context)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));

            _dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).Count();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
               
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<TodoItemModel> GetPage(int id, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id);
        }
               
        public virtual void Remove(int id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
        }
               
        public virtual void Update(TEntity entity)
        {
            _dbSet.AddOrUpdate(entity);
        }
    }
}
