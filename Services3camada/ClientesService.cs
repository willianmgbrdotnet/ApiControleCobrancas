using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiControleCobrancas.Data2camada;
using ApiControleCobrancas.Dominio1camada;

//Regras de Negócio implementadas
//Basicamente o CRUD normal, mas para remover um cliente, ele não deve ter 
//nenhuma cobrança vinculada, ou se tiver cobranças vinculadas, elas devem estar pagas.

namespace ApiControleCobrancas.Services3camada
{
    public class ClientesService
    {
        //instanciando a Segunda camada
        ClientesRepository clientesRepository = new ClientesRepository();

        public string AddCliente(string name, string telefone)
        {
            //O Id do novo cliente será a quantidade de clientes +1
            var clienteId = clientesRepository.ListSize() +1;
            //Salva um novo (cliente) do tipo Clientes
            clientesRepository.Save(new Clientes(clienteId, name, telefone));
            return("Cliente cadastrado com sucesso!");            
        }
        
        //verificar pelo Id se o cliente existe
        //Este método é necessário para Editar na Quarta Camada
        public bool VerificarPeloId(int clienteId)
        {
            var clienteVerificado = clientesRepository.GetById(clienteId);
            return clienteVerificado != null;
            //Exception será informada na Presentation
        }

        //Mostrar Dados do Cliente correspondente ao ID
        //Método necessário para Editar na Quarta Camada
        public void ShowClienteDoId(int clienteId)
        {
            Console.WriteLine($"O cliente do id informado é: {clientesRepository.GetById(clienteId).Nome} Tel {clientesRepository.GetById(clienteId).Telefone}");
        }

        public string ShowClientes()
        {
            var builder = new StringBuilder();
            //busca todos os clientes e armazena na variavel "clientesList"
            var clientesList = clientesRepository.GetAll();
            var quantidadeDeClientes = clientesList.Count;

            if(quantidadeDeClientes == 0)
            {
                return builder.Append("Lista vazia").ToString();
            }
            else
            {
                foreach (var cliente in clientesList)
                {
                    //Cada item encontrado na lista será adicionado à super string "builder"
                    //O StringBuilder pode manipular e apresentar as strings armazenadas na 
                    //variável "builder" de diversas formas.                      
                    builder.AppendLine("Id: " + cliente.Id + " Nome: " + cliente.Nome + " Telefone: " + cliente.Telefone);
                }
                return builder.ToString();
            }
        }

        //Assim como no Repositório, esse método também retornará um "bool"
        public bool EditarCliente(int clienteId, string clienteName, string clienteTelefone)
        {
            var alterarCliente = clientesRepository.GetById(clienteId);

            if(alterarCliente == null)
            {
                Console.WriteLine($"O cliente com o ID {clienteId} nao foi encontrado");
                return false;                
            }
            else
            {
                alterarCliente.Nome = clienteName;
                alterarCliente.Telefone = clienteTelefone;

                Console.WriteLine($"Cliente alterado com sucesso!");            
                return true;
            }            
        }

        public void ExcluirCliente(int clienteId)
        {
            clientesRepository.Delete(clienteId);
        }
    }
}