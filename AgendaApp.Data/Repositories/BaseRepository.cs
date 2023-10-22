using AgendaApp.Data.Interfaces;
using LiteDB;

namespace AgendaApp.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        #region Conexão com o banco de dados

        protected ILiteDatabase GetDatabase()
        {
            var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "agendaapp.db");
            return new LiteDatabase(filePath);
        }

        #endregion

        public virtual TEntity Create(TEntity data)
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<TEntity>();
                var id = collection.Insert(data);
                return collection.FindById(id);
            }
        }

        public virtual TEntity Update(TEntity data)
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<TEntity>();
                var id = collection.Upsert(data);
                return collection.FindById(id);
            }
        }

        public virtual TEntity Delete(ObjectId id)
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<TEntity>();
                var data = collection.FindById(id);
                collection.Delete(id);
                return data;
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<TEntity>();
                return collection.FindAll().ToList();
            }
        }

        public virtual TEntity GetById(ObjectId id)
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<TEntity>();
                return collection.FindById(id);
            }
        }
    }
}
