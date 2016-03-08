using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.Services
{
    public interface IBaseService<TEntity> where TEntity : IEntityModel
    {
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }
}
