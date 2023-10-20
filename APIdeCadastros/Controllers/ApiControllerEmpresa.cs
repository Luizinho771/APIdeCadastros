using APIdeCadastros.Entities;
using APIdeCadastros.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIdeCadastros.Controllers
{
    [Route("api/empresa")]
    [ApiController]
    public class ApiControllerEmpresa : ControllerBase
    {
        private readonly DbContext _dbContext;
        public ApiControllerEmpresa(DbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult GetEmpresas()
        {
            var lista = _dbContext.Empresas.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmpresaById(Guid id)
        {
            var empresa = _dbContext.Empresas.SingleOrDefault(x => x.Id == id);

            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }

        [HttpPost("{empresa}")]
        public IActionResult PostEmpresa(Empresa empresa)
        {
            if (ProcurarCnpj(empresa)){
                _dbContext.Empresas.Add(empresa);
                return CreatedAtAction(nameof(GetEmpresaById), new { id = empresa.Id }, empresa);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("{idEmpresa}/{funcionario}")]
        public IActionResult AddFuncionario(Guid IdEmpresa, Funcionario funcionario)
        {
            var empresa = _dbContext.Empresas.SingleOrDefault(x => x.Id == IdEmpresa);

            if (empresa == null)
            {
                return NotFound();
            }

            funcionario.Empresa = empresa;
            empresa.AddFuncionario(funcionario);
            return Ok(empresa);
        }


        private Boolean ProcurarCnpj(Empresa empresa)
        {
            var emp = _dbContext.Empresas.SingleOrDefault(x => x.Cnpj == empresa.Cnpj);
            if (emp == null)
            {
                return true;
            }
            return false;

        }
    }
}
