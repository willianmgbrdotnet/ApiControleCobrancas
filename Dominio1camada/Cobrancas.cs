using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControleCobrancas.Dominio1camada
{
    public class Cobrancas
    {
        public int Id { get; set; }
        //Data de emissao será setada pelo sistema quando a cobrança for gerada.
        public DateTime DataEmissao { get; set; }
        public DateTime DataAvencer { get; set; }
        public double ValorCobranca { get; set; }
        //Data de Pagamento será nula até que o pagamento ocorra.
        //Atente para o sinal de ? no tipo da Propriedade indicando que ela pode ser nula.
        public DateTime? DataPagamento { get; set; }
        //StatusPago será falso até o pagamento ser efetuado.
        public bool StatusPago { get; set; }

        //A Cobrança será instanciada e o cliente que já existe no banco de dados será vinculado à cobrança.
        //A partir desse ponto, os dados do cliente não poderá ser alterado.
        //Por isso o modificador de acesso "private" foi colocado no "set".
        public Clientes Clientes { get; private set; }

        public Cobrancas(int id, DateTime dataAvencer, double valorCobranca, Clientes clientes)
        {
            this.Id = id;
            this.DataEmissao = DateTime.Now;
            this.DataAvencer = dataAvencer;
            this.ValorCobranca = valorCobranca;
            this.DataPagamento = null;
            this.StatusPago = false;
            this.Clientes = clientes;
        }
    }
}