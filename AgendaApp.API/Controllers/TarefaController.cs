using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly DataContext? _dataContext;

        public TarefaController(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarefaEntity tarefa)
        {
            await _dataContext.AddAsync(tarefa);
            await _dataContext.SaveChangesAsync();

            return Ok(tarefa);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TarefaEntity tarefa)
        {
            _dataContext.Update(tarefa);
            await _dataContext.SaveChangesAsync();

            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tarefa = await _dataContext.Set<TarefaEntity>().FirstOrDefaultAsync(t => t.Id == id);
            _dataContext?.Remove(tarefa);
            await _dataContext.SaveChangesAsync();
                
            return Ok(tarefa);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarefas = await _dataContext.Set<TarefaEntity>().ToListAsync();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tarefa = await _dataContext?.Set<TarefaEntity>().FirstOrDefaultAsync(t => t.Id == id);
            return Ok(tarefa);
        }
    }
}
