using APIdeCadastros.Entities;

namespace APIdeCadastros.Persistence
{
    public class DbContext
    {
        public DbContext()
        {
            Empresas = new List<Empresa>();
            Departamentos = new List<Departamento>();
            Tarefas = new List<Tarefa>();
            Funcionarios = new List<Funcionario>();
        }

        public List<Empresa> Empresas { get; set;}
        public List<Departamento> Departamentos { get; set; }
        public List<Tarefa> Tarefas { get; set; }
        public List<Funcionario> Funcionarios { get; set; }

    }
}
