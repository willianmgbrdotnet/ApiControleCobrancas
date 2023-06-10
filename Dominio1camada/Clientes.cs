namespace ApiControleCobrancas.Dominio1camada
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //No tipo da Propriedade indica que ela pode ser nula.
        public string? Telefone { get; set; }
        
        //Metrodo construtor
        //Ao criar cada objeto, deve ser informado os (parametros)
        public Clientes(int id, string nome, string telefone)
        {
            //As Propriedades desta(this) Classe recebe(=) os parametros correspondentes do objeto(cliente) que for gerado.
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
        }
        
        
    }
}