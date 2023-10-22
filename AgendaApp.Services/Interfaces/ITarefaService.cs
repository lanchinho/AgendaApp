using AgendaApp.Services.Dtos;

namespace AgendaApp.Services.Interfaces
{
    public interface ITarefaService
    {
        TarefaDto Create(TarefaDto tarefa);
        TarefaDto Update(TarefaDto tarefa);
        TarefaDto Delete(string id);
        List<TarefaDto> GetAll();
        TarefaDto Get(string id);
        void SetDone(string id, bool done);
    }
}
