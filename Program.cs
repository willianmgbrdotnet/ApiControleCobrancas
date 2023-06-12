using ApiControleCobrancas.Apresentacao4Camada;

namespace ApiControleCobrancas
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientesCobrancasPresentation presentation = new ClientesCobrancasPresentation();
            presentation.Menu();
            
        }
    }
}