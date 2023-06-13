using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControleCobrancas.Data2camada;
using ApiControleCobrancas.Dominio1camada;

namespace ApiControleCobrancas.Services3camada
{
    public class CobrancasService
    {
        //instanciando a Segunda camada
        CobrancasRepository cobrancasRepository = new CobrancasRepository();

        //Seguindo o mesmo padrão da classe ClienteServices
        public void NovaCobranca(Cobrancas cobranca)
        {
            //O Id da nova cobrança será auto gerado
            var idDaCobranca = cobrancasRepository.ListSize() +1;
            Console.WriteLine($"Qual será o prazo?  Digite a quantidade de dias até o Dia do vencimento.");
            var prazodias = double.Parse(Console.ReadLine());

            cobrancasRepository.Save(new Cobrancas(idDaCobranca, DateTime.Now.AddDays(prazodias), cobranca.ValorCobranca, cobranca.Clientes));        
            Console.WriteLine($"Cobrança Registrada");                    
        }

        public void BuscarCobrancaPeloId(int cobrancaId)
        {
            cobrancasRepository.GetById(cobrancaId);
        }

        public void PagarCobranca(Cobrancas cobranca)
        {
            cobrancasRepository.Update(cobranca);
        }

        public void MostrarTodasCobrancasGeral()
        {
            Console.WriteLine($"Total de Cobranças de todos os clientes");            
            cobrancasRepository.GetAll();
        }

        public void ContarQuantidadeCobrancasGeral()
        {
            cobrancasRepository.ListSize();
        }

        public void MostrarDividasClienteUnico(int clienteId)
        {
            Console.WriteLine($"Cliente tem um total de {cobrancasRepository.GetAllCobrancasDoCliente(clienteId).Count()} cobranças em seu nome");
            cobrancasRepository.GetAllCobrancasDoCliente(clienteId);            
        }
    }
}