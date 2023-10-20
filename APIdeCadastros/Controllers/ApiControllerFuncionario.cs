using APIdeCadastros.Entities;
using APIdeCadastros.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIdeCadastros.Controllers
{
    [Route("api/funcionarios")]
    [ApiController]
    public class ApiControllerFuncionario : ControllerBase
    {

        private readonly DbContext _dbContext;
        public ApiControllerFuncionario(DbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult GetFuncionarios()
        {
            var lista = _dbContext.Funcionarios.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetFuncionarioById(Guid id)
        {
            var funcionario = _dbContext.Funcionarios.SingleOrDefault(x => x.Id == id);

            if(funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPost("{funcionario}")]
        public IActionResult PostFuncionario(Funcionario funcionario)
        {
            _dbContext.Funcionarios.Add(funcionario);

            return CreatedAtAction(nameof(GetFuncionarioById), new { id = funcionario.Id }, funcionario);
        }

        [HttpPut("{idFuncionario}/{tarefa}")]
        public IActionResult AddTarefa(Guid IdFuncionario, Tarefa tarefa)
        {

            var funcionario = _dbContext.Funcionarios.SingleOrDefault(x => x.Id == IdFuncionario);

            if (funcionario == null && funcionario.Departamento != tarefa.Departamento)
            {
                return NotFound();
            }

            funcionario.AddTarefa(tarefa);
            return Ok(funcionario);
        }


    }
}
