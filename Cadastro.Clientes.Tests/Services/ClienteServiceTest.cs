using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Tests.Services.Fixtures;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Tests.Services
{
    [ExcludeFromCodeCoverage]
    [Collection(nameof(ClienteServiceFixtureCollection))]
    public class ClienteServiceTest
    {
        private readonly ClienteServiceFixture _clienteServiceFixture;

        public ClienteServiceTest(ClienteServiceFixture clienteServiceFixture)
        {
            _clienteServiceFixture = clienteServiceFixture;
        }




        [Theory(DisplayName = "ClienteServiceTest")]
        [Trait("ClienteService", "ClienteService")]
        [InlineData()]
        public async Task ClienteServiceIncluirTest()
        {
            ///Arrange
            var clienteRandom = _clienteServiceFixture.ObterCliente();
            var serviceCliente = _clienteServiceFixture.ObterService(clienteRandom, true);


            ///Action
            var clietneIncluido = await serviceCliente.Incluir(clienteRandom);


            ///Assert
            Assert.NotNull(clietneIncluido);
            Assert.NotEmpty(clietneIncluido.Nome);
            Assert.NotEmpty(clietneIncluido.CPFCNPJ);
            Assert.NotEmpty(clietneIncluido.Telefone);
            Assert.NotEmpty(clietneIncluido.Celular);

            Assert.NotNull(clietneIncluido.Endereco);
            Assert.NotEmpty(clietneIncluido.Endereco.CEP);
            Assert.NotEmpty(clietneIncluido.Endereco.Logradouro);
            Assert.NotEmpty(clietneIncluido.Endereco.Numero);
            Assert.NotEmpty(clietneIncluido.Endereco.Cidade);
            Assert.NotEmpty(clietneIncluido.Endereco.UF);
            Assert.NotEmpty(clietneIncluido.Endereco.Complemento);

        }


        [Theory(DisplayName = "ClienteServiceTest")]
        [Trait("ClienteService", "ClienteService")]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ClienteServiceAtualizarTest(bool operationSucesso)
        {
            ///Arrange
            var clienteRandom = _clienteServiceFixture.ObterCliente();
            var serviceCliente = _clienteServiceFixture.ObterService(clienteRandom, operationSucesso);


            ///Action
            var messageResponse = await serviceCliente.Alterar(clienteRandom);
            serviceCliente.InformarMessageOperation(messageResponse.Message, messageResponse.StatusCode, messageResponse.Sucesso,
                ref messageResponse);

            ///Assert
            Assert.NotNull(messageResponse);
            Assert.NotEmpty(messageResponse.Message);


            if (!operationSucesso)
                Assert.True(!messageResponse.Sucesso);

            else
                Assert.True(messageResponse.Sucesso);
        }


        [Theory(DisplayName = "ClienteServiceExcluirTest")]
        [Trait("ClienteService", "ClienteService")]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ClienteServiceExcluirTest(bool operationSucesso)
        {
            ///Arrange
            var clienteRandom = _clienteServiceFixture.ObterCliente();
            var serviceCliente = _clienteServiceFixture.ObterService(clienteRandom, operationSucesso);


            ///Action
            var messageResponse = await serviceCliente.Excluir(clienteRandom.IdCliente);


            ///Assert
            Assert.NotNull(messageResponse);
            Assert.NotEmpty(messageResponse.Message);
            Assert.NotEmpty(messageResponse.StatusCode.ToString());
        }


        [Theory(DisplayName = "ClienteServiceInstanceTest")]
        [Trait("ClienteService", "ClienteService")]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ClienteServiceInstanceTest(bool operationSucesso)
        {
            ///Arrange
            ///
            var rand = new Random();
            var clienteRandom = new Cliente();
            clienteRandom.Nome = rand.Next(0, 100).ToString();
            clienteRandom.CPFCNPJ = rand.Next(0, 100).ToString();
            clienteRandom.Telefone = rand.Next(0, 100).ToString();
            clienteRandom.Celular = rand.Next(0, 100).ToString();



            ///Action
            clienteRandom.Endereco = new Domain.Domains.Bases.Endereco();
            clienteRandom.Endereco.CEP = rand.Next(0, 100).ToString();
            clienteRandom.Endereco.Logradouro = rand.Next(0, 100).ToString();
            clienteRandom.Endereco.Numero = rand.Next(0, 1020).ToString();
            clienteRandom.Endereco.Cidade = rand.Next(0, 1100).ToString();
            clienteRandom.Endereco.UF = rand.Next(0, 1003).ToString();
            clienteRandom.Endereco.Complemento = rand.Next(0, 1020).ToString();



            ///Assert
            Assert.NotNull(clienteRandom);
            Assert.NotEmpty(clienteRandom.Nome);
            Assert.NotEmpty(clienteRandom.CPFCNPJ);
            Assert.NotEmpty(clienteRandom.Telefone);
            Assert.NotEmpty(clienteRandom.Celular);

            Assert.NotNull(clienteRandom.Endereco);
            Assert.NotEmpty(clienteRandom.Endereco.CEP);
            Assert.NotEmpty(clienteRandom.Endereco.Logradouro);
            Assert.NotEmpty(clienteRandom.Endereco.Numero);
            Assert.NotEmpty(clienteRandom.Endereco.Cidade);
            Assert.NotEmpty(clienteRandom.Endereco.UF);
            Assert.NotEmpty(clienteRandom.Endereco.Complemento);
            Assert.NotEmpty(clienteRandom.ToString());
            Assert.True(clienteRandom.PossuiCamposPreenchidos());
        }


        [Theory(DisplayName = "ClienteServiceGetAllTest")]
        [Trait("ClienteService", "ClienteService")]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ClienteServiceGetAllTest(bool operationSucesso)
        {
            ///Arrange
            var clienteRandom = _clienteServiceFixture.ObterCliente();
            var serviceCliente = _clienteServiceFixture.ObterService(clienteRandom, operationSucesso);


            ///Action
            var listaClientes = await serviceCliente.GetAll();


            ///Assert
            Assert.NotNull(listaClientes);
            Assert.True(listaClientes.Any());
          
        }


        [Theory(DisplayName = "ClienteServiceGetByClienteTest")]
        [Trait("ClienteService", "ClienteService")]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ClienteServiceGetByClienteTest(bool operationSucesso)
        {
            ///Arrange
            var clienteRandom = _clienteServiceFixture.ObterCliente();
            var serviceCliente = _clienteServiceFixture.ObterService(clienteRandom, operationSucesso);


            ///Action
            var listaClientes = await serviceCliente.GetByCliente(clienteRandom);


            ///Assert
            Assert.NotNull(listaClientes);
            Assert.True(listaClientes.Any());

        }

    }
}
