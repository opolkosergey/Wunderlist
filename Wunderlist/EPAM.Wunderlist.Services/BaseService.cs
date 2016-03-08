using System;
using System.Reflection;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.LoggerService;
using System.Linq;

namespace EPAM.Wunderlist.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class, IEntityModel
    {
        protected readonly IUnitOfWork WorkWithMssql;
        protected readonly ILoggerService Logger;
        private readonly string[] _updateExcludePropNames;

        protected BaseService(IUnitOfWork workWithMssql, ILoggerService logger, string[] updateExcludePropNames)
        {
            if (workWithMssql == null)
                throw new ArgumentNullException(nameof(workWithMssql));

            if(logger == null)
                throw new ArgumentNullException(nameof(logger));

            WorkWithMssql = workWithMssql;
            Logger = logger;
            _updateExcludePropNames = updateExcludePropNames;
        }

        public virtual void Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                GetRepository.Add(entity);
                WorkWithMssql.Commit();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }

        public virtual TEntity GetById(int id)
        {
            return GetRepository.GetById(id);
        }

        public virtual void Remove(int id)
        {
            try
            {
                if (id < 0)
                    throw new ArgumentException(nameof(id));

                GetRepository.Remove(id);
                WorkWithMssql.Commit();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                var targerEntity = GetById(entity.Id);
                ComparisonPropertyValues(entity, targerEntity);
                GetRepository.Update(targerEntity);
                WorkWithMssql.Commit();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }

        protected virtual TEntity ComparisonPropertyValues(TEntity source, TEntity target)
        {
            if (source == null || target == null)
                return null;
            
            PropertyInfo[] entityProp = typeof (TEntity).GetProperties();

            foreach (var targetProp in entityProp)
            {
                if (ExcludeFromComparison(targetProp.Name))
                {
                    if (targetProp.CanWrite)
                        targetProp.SetValue(target, targetProp.GetValue(source));
                }
            }

            return target;
        }
        
        protected virtual bool ExcludeFromComparison(string excludeProp)
        {
            return !_updateExcludePropNames.Contains(excludeProp);
        }

        protected abstract IRepository<TEntity> GetRepository { get; }
    }
}
