using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            cobrancasRepository.Save(cobranca);
        }

        public void BuscarCobrancaPeloId(int cobrancaId)
        {
            cobrancasRepository.GetById(cobrancaId);
        }

        public void PagarCobrancaDarBaixa(Cobrancas cobranca)
        {
            cobrancasRepository.Update(cobranca);
        }

        public string MostrarTodasCobrancasGeral()
        {
            var builder = new StringBuilder();
            //busca todos os clientes e armazena na variavel "clientesList"
            var cobrancasLista = cobrancasRepository.GetAll();
            var quantidadeDeClientes = cobrancasLista.Count;

            if(quantidadeDeClientes == 0)
            {
                return builder.Append("Lista vazia").ToString();
            }
            else
            {
                foreach (var cobranca in cobrancasLista)
                {
                    //Cada item encontrado na lista será adicionado à super string "builder"
                    //O StringBuilder pode manipular e apresentar as strings armazenadas na 
                    //variável "builder" de diversas formas.                      
                    builder.AppendLine("IdCobrança: " + cobranca.Id + " DataEmissao: " + cobranca.DataEmissao + " DataVencimento: " + cobranca.DataAvencer + " ValorCobrança " + cobranca.ValorCobranca + " Data que foi paga " + cobranca.DataPagamento + " Foi paga? " + cobranca.StatusPago);
                }
                return builder.ToString();
            }
        }


        public void ContarQuantidadeCobrancasGeral()
        {
            cobrancasRepository.ListSize();
        }

        public string MostrarDividasClienteUnico(int clienteId)
        {

            var builder = new StringBuilder();
            //busca todos os clientes e armazena na variavel "clientesList"
            var dividasDoCliente = cobrancasRepository.GetAllCobrancasDoCliente(clienteId);
            Console.WriteLine($"Cliente tem um total de {dividasDoCliente.Count()} cobranças em seu nome");

            if(dividasDoCliente.Count == 0)
            {
                return builder.Append("Lista vazia").ToString();
            }
            else
            {
                foreach (var cobranca in dividasDoCliente)
                {
                    //Cada item encontrado na lista será adicionado à super string "builder"
                    //O StringBuilder pode manipular e apresentar as strings armazenadas na 
                    //variável "builder" de diversas formas.                      
                    builder.AppendLine("IdCobrança: " + cobranca.Id + " DataEmissao: " + cobranca.DataEmissao + " DataVencimento: " + cobranca.DataAvencer + " ValorCobrança " + cobranca.ValorCobranca + " Data que foi paga " + cobranca.DataPagamento + " Foi paga? " + cobranca.StatusPago);
                }
                return builder.ToString();
            }
        }
    }
}