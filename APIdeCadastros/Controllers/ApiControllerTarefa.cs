using APIdeCadastros.Entities;
using APIdeCadastros.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIdeCadastros.Controllers
{
    [Route("api/tarefa")]
    [ApiController]
    public class ApiControllerTarefa : ControllerBase
    {

        private readonly DbContext _dbContext;
        public ApiControllerTarefa(DbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult GetTarefas()
        {
            var lista = _dbContext.Tarefas.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetTarefaById(Guid id)
        {
            var tarefa = _dbContext.Tarefas.SingleOrDefault(x => x.Id == id);

            if(tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPost("{tarefa}")]
        public IActionResult PostTarefa(Tarefa tarefa)
        {
            _dbContext.Tarefas.Add(tarefa);

            return CreatedAtAction(nameof(GetTarefaById), new { id = tarefa.Id }, tarefa);
        }


        
    }
}
