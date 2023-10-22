using AgendaApp.Data.Interfaces;
using AgendaApp.Data.Models;

namespace AgendaApp.Data.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public override List<Tarefa> GetAll()
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<Tarefa>();
                return collection.FindAll()
                    .OrderByDescending(x => x.DueTime)
                    .ToList();
            }
        }
    }
}
