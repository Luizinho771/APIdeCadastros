using APIdeCadastros.Entities;
using APIdeCadastros.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIdeCadastros.Controllers
{
    [Route("api/departamento")]
    [ApiController]
    public class ApiControllerDepartamento : ControllerBase
    {

        private readonly DbContext _dbContext;
        public ApiControllerDepartamento(DbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            var lista = _dbContext.Departamentos.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartamentoById(Guid id)
        {
            var departamento = _dbContext.Departamentos.SingleOrDefault(x => x.Id == id);

            if(departamento == null)
            {
                return NotFound();
            }
            return Ok(departamento);
        }

        [HttpPost("{departamento}")]
        public IActionResult PostDepartamentos(Departamento departamento)
        {
            _dbContext.Departamentos.Add(departamento);

            return CreatedAtAction(nameof(GetDepartamentoById), new { id = departamento.Id }, departamento);
        }

        [HttpPut("{idDepartamento}/{funcionario}")]
        public IActionResult AddFuncionario(Guid IdDepartameno, Funcionario funcionario) {

            var departamento = _dbContext.Departamentos.SingleOrDefault(x => x.Id == IdDepartameno);

            if (departamento == null)
            {
                return NotFound();
            }

            funcionario.Departamento = departamento;
            departamento.AddFuncionario(funcionario);

            return Ok(departamento);
        }

        [HttpPut("{idDepartamento}/{tarefa}")]
        public IActionResult AddTarefa(Guid IdDepartameno, Tarefa tarefa)
        {

            var departamento = _dbContext.Departamentos.SingleOrDefault(x => x.Id == IdDepartameno);

            if (departamento == null)
            {
                return NotFound();
            }

            departamento.AddTarefa(tarefa);
            return Ok(departamento);
        }

    }
}
