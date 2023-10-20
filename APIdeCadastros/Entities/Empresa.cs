namespace APIdeCadastros.Entities
{
    public class Empresa
    {
        public Empresa(string nome, string cnpj)
        {
            ListaDepartamentos = new List<Departamento>();
            ListaFuncionarios = new List<Funcionario>();  
            Nome = nome;
            Cnpj = cnpj;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set;}
        public List<Departamento> ListaDepartamentos { get; set; }
        public List<Funcionario> ListaFuncionarios { get; set; }


        public void AddFuncionario(Funcionario Funcionario)
        {
            ListaFuncionarios.Add(Funcionario);
        }

        public void AddDepartamento(Departamento Departamento)
        {
            ListaDepartamentos.Add(Departamento);
        }
    }
}
