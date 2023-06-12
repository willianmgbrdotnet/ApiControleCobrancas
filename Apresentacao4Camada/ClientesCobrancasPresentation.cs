using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControleCobrancas.Services3camada;

namespace ApiControleCobrancas.Apresentacao4Camada
{
    public class ClientesCobrancasPresentation
    {
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
                Console.WriteLine($"0 para Sair");
                
                
                opcaoUsuario = Console.ReadLine();

                switch(opcaoUsuario)
                {
                    case "0":
                        Environment.Exit(0);
                    break;

                    case "1":
                        Console.WriteLine($"Digite o nome do cliente");
                        string clienteName = Console.ReadLine();
                        Console.WriteLine($"Digite o numero de telefone do cliente");
                        string clienteTelefone = Console.ReadLine();

                        var response = clientesService.AddCliente(clienteName, clienteTelefone);
                        Console.WriteLine(response);
                        Console.WriteLine();                        
                    break;

                    case "2":
                        Console.WriteLine(clientesService.ShowClientes());
                        Console.WriteLine();
                    break;
                }
                
            }
        }

    }
}