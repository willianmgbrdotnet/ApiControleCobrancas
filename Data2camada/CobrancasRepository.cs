using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControleCobrancas.Dominio1camada;

namespace ApiControleCobrancas.Data2camada
{
    public class CobrancasRepository
    {
        private List<Cobrancas> cobrancasLista = new List<Cobrancas>();

        //Salva um (objeto cobrança do tipo Cobranças)
        public void Save(Cobrancas cobranca)
        {
            cobrancasLista.Add(cobranca);
        }

        public Cobrancas GetById(int cobrancaId)
        {
            return cobrancasLista.Find(x => x.Id == cobrancaId);
        }

        //Esse Update será diferente do "ClientesRepository"
        //A cobrança será atualizada quando ela for paga. Então, as propriedades
        //que serão modificadas serão a data de pagamento que está nula e o status que esta false.
        public void Update(Cobrancas cobranca)
        {
            cobranca.DataPagamento = DateTime.Now;
            cobranca.StatusPago = true;
        }

        public bool Delete(int cobrancaId)
        {
            var deleteCobranca = cobrancasLista.Find(x => x.Id == cobrancaId);

            if(cobrancaId == null)
                return false;
            else
            {
                cobrancasLista.Remove(deleteCobranca);
                return true;
            }
        }

        public List<Cobrancas> GetAll()
        {
            return cobrancasLista;
        }

        public int ListSize()
        {
            return cobrancasLista.Count;
        }

        //Lista todas as cobranças de um único cliente.
        public List<Cobrancas> GetAllCobrancasDoCliente(int clienteId)
        {
            var TodasCobrancasDoCliente = cobrancasLista.FindAll(x => x.Id == clienteId);
            return TodasCobrancasDoCliente;
        }
    }
}