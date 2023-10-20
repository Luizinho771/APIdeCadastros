namespace APIdeCadastros.Entities
{
    public class Funcionario
    {
        public Funcionario(string nome, string cpf)
        {
            ListaTarefas = new List<Tarefa>();
            Nome = nome;
            Cpf = cpf;
            Empresa = null;
            Departamento = null;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Empresa Empresa { get; set; }
        public Departamento Departamento { get; set; }
        public List<Tarefa> ListaTarefas { get; set; }


        public void AddTarefa(Tarefa Tarefa)
        {
            ListaTarefas.Add(Tarefa);
        }

    }
}
