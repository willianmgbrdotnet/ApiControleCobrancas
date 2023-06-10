using ApiControleCobrancas.Dominio1camada;

namespace ApiControleCobrancas.Data2camada
{
    public class ClientesRepository
    {
        //Os clientes serão armazenados em uma Lista na memória em tempo de execução.
        private List<Clientes> clientesLista = new List<Clientes>();

        
        public void Save(Clientes cliente)
        {
            clientesLista.Add(cliente);
        }

        //Busca pelo Id os dados do cliente na lista
        public Clientes GetById(int clienteId)
        {
            //Encontre o objeto da lista "clientesLista" cuja propriedade Id seja igual ao valor de "clienteId".
            return clientesLista.Find(x => x.Id == clienteId);
        }

        public bool Update(Clientes cliente)
        {
            //armazena o objeto encontrado na variável "editCliente"
            var editCliente = clientesLista.Find(x => x.Id == cliente.Id);

            //primeiro é preciso verificar se existe o objeto cliente na lista de clientes.
            if(editCliente == null)
                return false;
            else
            {
                editCliente.Nome = cliente.Nome;
                editCliente.Telefone = cliente.Telefone;
                return true;
            }            
        }

        public bool Delete(int clienteId)
        {
            var deleteCliente = clientesLista.Find(x => x.Id == clienteId);

            if(deleteCliente == null)
                return false;
            else
            {
                clientesLista.Remove(deleteCliente);
                return true;
            }
        }

        //Lista todos os objetos da lista de clientes 
        public List<Clientes> GetAll()
        {
            return clientesLista;
        }

        //Lista a quantidade de objetos na lista
        public int ListSize()
        {
            return clientesLista.Count;
        }

    }
}