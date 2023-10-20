namespace APIdeCadastros.Entities
{
    public class Tarefa
    {
        public Tarefa(string nome, Departamento departamento)
        {
            ListaFuncionariosTarefa = new List<Funcionario>();
            Nome = nome;
            Departamento = departamento;

        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Departamento Departamento { get; set; }
        public List<Funcionario> ListaFuncionariosTarefa { get; set; }


        public void AddFuncionario(Funcionario Funcionario)
        {
            ListaFuncionariosTarefa.Add(Funcionario);
        }
    }
}
