using LiteDB;

namespace AgendaApp.Data.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        TEntity Create(TEntity data);
        TEntity Update(TEntity data);
        TEntity Delete(ObjectId id);
        List<TEntity> GetAll();
        TEntity GetById(ObjectId id);
    }
}
