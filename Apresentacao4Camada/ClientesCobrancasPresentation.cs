using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControleCobrancas.Services3camada;

namespace ApiControleCobrancas.Apresentacao4Camada
{
    public class ClientesCobrancasPresentation
    {
        //instanciando a Terceira camada
        ClientesService clientesService = new ClientesService();
        CobrancasService cobrancasService = new CobrancasService();

        //Através desse menu, o usuario vai interagir com a Terceira camada.
        public void Menu()
        {
            string opcaoUsuario = String.Empty;

            while (opcaoUsuario != "0")
            {
                Console.WriteLine($"Digite 1 para adicionar um novo cliente");
                Console.WriteLine($"Digite 2 para listar todos os clientes");
                Console.WriteLine($"Digite 3 para editar um cliente");
                Console.WriteLine($"Digite 4 para mostrar o cliente do id que você informar");
                Console.WriteLine($"Digite 7 para Excluir o cliente desejado.");
                System.Console.WriteLine();
                Console.WriteLine($"11 (onze) para registrar uma nova Cobrança");
                Console.WriteLine($"22 para mostrar Todas as Cobranças");
                System.Console.WriteLine();                
                Console.WriteLine($"Aperte o 9 para limpar a Telar");                
                Console.WriteLine($"0 para Sair");
                Console.WriteLine();
                                
                
                opcaoUsuario = Console.ReadLine();

                switch(opcaoUsuario)
                {
                    case "11":
                        

                    break;
                        


                    case "9":
                        Console.Clear();
                    break;

                    case "0":
                        Environment.Exit(0);
                    break;

                    case "1":
                        AdicionarCliente();
                        break;

                    case "2":
                        Console.WriteLine(clientesService.ShowClientes());
                    break;

                    case "3":
                        AtualizarDadosCliente();
                        break;

                    case "4":
                        VerificarClientePeloId();
                    break;

                    case "7":
                        RemoverCliente();
                    break;
                }
                
            }
        }

        private void RemoverCliente()
        {
            Console.WriteLine("Este procedimento vai APAGAR o cliente para sempre.");
            Console.WriteLine("Tem certeza que você quer APAGAR o cliente ??");
            Console.WriteLine();
            Console.WriteLine("Aperte 7 para APAGAR o cliente então.");
            Console.WriteLine("Se mudou de Idéia e quer voltar, aperte Outro Número. ");
            Console.WriteLine();
            string resposta = Console.ReadLine();
            if(resposta == "7")
            {
            try
            {
                Console.WriteLine($"Qual o id do cliente que você quer Excluir?");
                var idDoCliente = int.Parse(Console.ReadLine());
                clientesService.ExcluirCliente(idDoCliente);
                System.Console.WriteLine("Exclusão Concluída");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Valor inválido");
                Console.WriteLine(clientesService.ShowClientes());
            }
            }
            else
                Menu();

        }

        private void VerificarClientePeloId()
        {
            try
            {
                Console.WriteLine($"Qual Id você quer verificar?");
                var idDoCliente = int.Parse(Console.ReadLine());
                clientesService.ShowClienteDoId(idDoCliente);
                System.Console.WriteLine();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Valor inválido");
                Console.WriteLine(clientesService.ShowClientes());
            }
        }

        private void AtualizarDadosCliente()
        {
            Console.WriteLine($"Qual é o Id do cliente que você quer modificar?");
            //O "try catch" é usado para impedir que o programa trave caso o usuário digitar um valor inválido.
            try
            {
                //Primeiramente verifica-se se o valor digitado corresponde a algum cliente na instância.
                int idDoClienteX = int.Parse(Console.ReadLine());
                bool clienteExiste = clientesService.VerificarPeloId(idDoClienteX);

                clientesService.ShowClienteDoId(idDoClienteX);
                System.Console.WriteLine();
                Console.WriteLine($"Digite o novo nome do cliente");
                var novoNome = Console.ReadLine();
                System.Console.WriteLine();
                Console.WriteLine($"Digite o novo Telefone do cliente");
                var novoTelefone = Console.ReadLine();

                //agora, reescreve os valores digitados pelo usuário nos parâmetros correspondentes da instância.
                var clienteModificado = clientesService.EditarCliente(idDoClienteX, novoNome, novoTelefone);
                clientesService.ShowClienteDoId(idDoClienteX);
                System.Console.WriteLine();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"ID incorreto! O valor digitado não corresponde a um cliente valido");
                System.Console.WriteLine();
                Console.WriteLine(clientesService.ShowClientes());
                Menu();
            }
        }

        private void AdicionarCliente()
        {
            Console.WriteLine($"Digite o nome do cliente e aperte ENTER para confirmar");
            string clienteName = Console.ReadLine();
            Console.WriteLine($"Digite o numero de telefone do cliente e aperte ENTER para confirmar");
            string clienteTelefone = Console.ReadLine();

            var response = clientesService.AddCliente(clienteName, clienteTelefone);
            Console.WriteLine(response);
            Console.WriteLine();
        }
    }
}