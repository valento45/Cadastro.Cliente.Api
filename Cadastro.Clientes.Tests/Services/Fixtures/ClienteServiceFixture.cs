using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Domain.Dto;
using Cadastro.Clientes.Domain.Responses;
using Cadastro.Clientes.Repository.Repositorys.Interfaces;
using Cadastro.Clientes.Service.Services;
using Cadastro.Clientes.Service.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Tests.Services.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class ClienteServiceFixture
    {

        public IClienteRepository ObterRepository()
        {
            var clienteRepository = new Mock<IClienteRepository>();
            return clienteRepository.Object;

        }
        public ClienteService ObterService(Cliente cliente, bool sucessoOperation)
        {
            var clienteRepository = new Mock<IClienteRepository>();
            clienteRepository.Setup(x => x.Incluir(cliente)).Returns(ClienteRetorno(cliente));
            clienteRepository.Setup(x => x.Alterar(cliente)).Returns(Task.FromResult(sucessoOperation));
            clienteRepository.Setup(x => x.Excluir(cliente.IdCliente)).Returns(Task.FromResult(sucessoOperation));
            clienteRepository.Setup(x => x.ExcluirPorEmail(cliente.Email)).Returns(Task.FromResult(sucessoOperation));
            clienteRepository.Setup(x => x.GetAll(0)).Returns(Task.FromResult(ObterAllClientes()));
            clienteRepository.Setup(x => x.GetByCliente(cliente)).Returns(Task.FromResult(ObterAllClientes()));
            clienteRepository.Setup(x => x.ExisteCliente(cliente)).Returns(Task.FromResult(sucessoOperation));
            clienteRepository.Setup(x => x.ExisteCliente(cliente.IdCliente)).Returns(Task.FromResult(sucessoOperation));
            


            var service = new Mock<ClienteService>(clienteRepository.Object);            

            return service.Object;
        }

        
        public Cliente ObterCliente()
        {
            Random rand = new Random();
            var cliente = new Cliente();

            cliente.Nome = rand.Next(0, 100).ToString();
            cliente.CPFCNPJ = rand.Next(0, 100).ToString();
            cliente.Telefone = rand.Next(0, 100).ToString();
            cliente.Celular = rand.Next(0, 100).ToString();
            cliente.Email = rand.Next(0, 100).ToString();
            cliente.Endereco = new Domain.Domains.Bases.Endereco();
            cliente.Endereco.CEP = rand.Next(0, 100).ToString();
            cliente.Endereco.Logradouro = rand.Next(0, 100).ToString();
            cliente.Endereco.Numero = rand.Next(0, 1020).ToString();
            cliente.Endereco.Cidade = rand.Next(0, 1100).ToString();
            cliente.Endereco.UF = rand.Next(0, 1003).ToString();
            cliente.Endereco.Complemento = rand.Next(0, 1020).ToString();

            return cliente;
        }

     

        public IEnumerable<Cliente> ObterAllClientes()
        {
            List<Cliente> result = new List<Cliente>();
            Random rand = new Random();

            var qtdClientes = rand.Next(1, 50);

            for(int i = 0; i < qtdClientes; i++)
            {
                var cliente = ObterCliente();
                cliente.IdCliente = i + 1;              

                result.Add(cliente);
            }
         

            return result;
        }

        public async Task<MessageResponse> ObterMessageResponse(bool operationSucesso)
        {
            var response = new MessageResponse();
            response.InformarSucesso(operationSucesso);
            response.InformarMessage($"Message - {operationSucesso}");

            if (operationSucesso)
                response.InformarStatusCode(200);
            else
                response.InformarStatusCode(500);


            return response;
        }

        public async Task<Cliente> ClienteRetorno(Cliente cliente)
        {
            Random rand = new Random();
            cliente.IdCliente = rand.Next(0, 1000);

            return cliente;
        }

    }

    [ExcludeFromCodeCoverage]
    [CollectionDefinition(nameof(ClienteServiceFixtureCollection))]
    public class ClienteServiceFixtureCollection : ICollectionFixture<ClienteServiceFixture>
    {

    }
}
