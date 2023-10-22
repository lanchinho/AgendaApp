using AgendaApp.Data.Interfaces;
using AgendaApp.Services.Dtos;
using AgendaApp.Services.Interfaces;
using LiteDB;
using AgendaApp.Data.Models;
using System.Net.Http.Headers;

namespace AgendaApp.Services.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public TarefaDto Create(TarefaDto tarefa)
        {
            var result = _repository.Create(new Tarefa
            {
                Id = ObjectId.NewObjectId(),
                Title = tarefa.Title,
                Description = tarefa.Description,
                DueTime = tarefa.DueTime,
                Done = false
            });

            return ToDto(result);
        }

        public TarefaDto Delete(string id)
        {
            var model = _repository.Delete(new ObjectId(id));
            return ToDto(model);
        }

        public TarefaDto Get(string id)
        {
            var model = _repository.GetById(new ObjectId(id));
            return ToDto(model);
        }

        public List<TarefaDto> GetAll()
        {
            return _repository.GetAll().Select(t => new TarefaDto
            {
                Id = t.Id.ToString(),
                Title = t.Title,
                Description = t.Description,
                DueTime = t.DueTime,
                Done = t.Done
            }).ToList();
        }

        public void SetDone(string id, bool done)
        {
            var model = _repository.GetById(new ObjectId(id));
            model.Done = done;
            _repository.Update(model);
        }

        public TarefaDto Update(TarefaDto tarefa)
        {
            var result = _repository.Update(new Tarefa
            {
                Id = ObjectId.NewObjectId(),
                Title = tarefa.Title,
                Description = tarefa.Description,
                DueTime = tarefa.DueTime,
                Done = false
            });

            return ToDto(result);
        }

        #region Helper Methods
        
        private static TarefaDto ToDto(Tarefa result)
        {
            return new TarefaDto
            {
                Id = result.Id.ToString(),
                Title = result.Title,
                Description = result.Description,
                DueTime = result.DueTime,
                Done = result.Done
            };
        }

        #endregion
    }
}
