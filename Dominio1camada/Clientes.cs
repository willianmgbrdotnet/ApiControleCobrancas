namespace ApiControleCobrancas.Dominio1camada
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //No tipo da Propriedade indica que ela pode ser nula.
        public string? Telefone { get; set; }
        //Um cliente pode ter nenhuma ou várias cobranças. Por isso, 
        //as cobranças serão do tipo "Lista de Cobranças".
        public List<Cobrancas> Cobrancas { get; set; }
        
        //Metrodo construtor
        //Ao criar cada objeto, deve ser informado os (parametros)
        public Clientes(int id, string nome, string telefone)
        {
            //As Propriedades desta(this) Classe recebem(=) os parametros correspondentes do objeto(cliente) que for gerado.
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Cobrancas = new List<Cobrancas>();

        }
        
    }
}