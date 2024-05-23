using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Tests.Domains.Fixtures;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Tests.Domains
{
    [ExcludeFromCodeCoverage]
    [Collection(nameof(ClienteDomainFixtureCollection))]
    public class ClienteDomainTest
    {
        private readonly ClienteDomainFixture _clienteDomainFixture;

        public ClienteDomainTest(ClienteDomainFixture clienteDomainFixture)
        {
            _clienteDomainFixture = clienteDomainFixture ?? throw new ArgumentException(nameof(clienteDomainFixture));
        }

        [Theory(DisplayName = "TestaClienteDomain")]
        [Trait("ClienteDomain", "Domain")]
        [InlineData(2, "Leonidas FULL", "3123213", "321321", "3333", "221223", "3333", "2222", "3333", "222", "33")]
        [InlineData(3, "MEliodas full", "412421412.0030/32-3", "4343", "4343", "4343", "4343", "4343", "4343", "5343", "5555")]
        [InlineData(4, "Naruto full", "123411412.0030/32-3", "4343", "4343", "4343", "4343", "4343", "4343", "5343", "5555")]
        public async Task TestaDomainsCliente(int idCliente, string nome, string cpfcnpj, string telefone, string celular, string cep,
            string logradouro, string numero, string cidade, string uf, string complemento)
        {


            var cliente = _clienteDomainFixture.ObterCliente(idCliente, nome, cpfcnpj, telefone, celular, cep,
                logradouro, numero, cidade, uf, complemento);


            Assert.NotNull(cliente);
            Assert.NotEmpty(cliente.Nome);
            Assert.NotEmpty(cliente.CPFCNPJ);
            Assert.NotEmpty(cliente.Telefone);
            Assert.NotEmpty(cliente.Celular);

            Assert.NotNull(cliente.Endereco);
            Assert.NotEmpty(cliente.Endereco.CEP);
            Assert.NotEmpty(cliente.Endereco.Logradouro);
            Assert.NotEmpty(cliente.Endereco.Numero);
            Assert.NotEmpty(cliente.Endereco.Cidade);
            Assert.NotEmpty(cliente.Endereco.UF);
            Assert.NotEmpty(cliente.Endereco.Complemento);
        }
    }
}
