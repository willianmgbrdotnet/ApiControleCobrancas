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

        public Cobrancas(int id, DateTime dataAvencer, double valorCobranca)
        {
            this.Id = id;
            this.DataEmissao = DateTime.Now;
            this.DataAvencer = dataAvencer;
            this.ValorCobranca = valorCobranca;
            this.DataPagamento = null;
            this.StatusPago = false;

        }
    }
}