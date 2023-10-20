namespace APIdeCadastros.Entities
{
    public class Departamento
    {
        public Departamento(string nome)
        {
            ListaFuncionariosDepartamento = new List<Funcionario>();
            ListaTarefas = new List<Tarefa>(); 
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Funcionario> ListaFuncionariosDepartamento { get; set; }
        public List<Tarefa> ListaTarefas { get; set; }


        public void AddFuncionario(Funcionario Funcionario)
        {
            ListaFuncionariosDepartamento.Add(Funcionario);
        }

        public void AddTarefa(Tarefa Tarefa)
        {
            ListaTarefas.Add(Tarefa);
        }

    }
}
