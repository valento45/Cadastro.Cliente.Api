using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Tests.Domains.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class ClienteDomainFixture
    {
        public Cliente ObterCliente(int idCliente, string nome, string cpfcnpj, string telefone, string celular, string cep,
            string logradouro, string numero, string cidade, string uf, string complemento)
        {


             var cliente = new Cliente()
              {
                  IdCliente = idCliente,
                  Nome = nome,
                  CPFCNPJ = cpfcnpj,
                  Telefone = telefone,
                  Celular = celular
              };

            cliente.Endereco = new Domain.Domains.Bases.Endereco()
            {
                CEP = cep,
                Logradouro = logradouro,
                Numero = numero,
                Cidade = cidade,
                UF = uf,
                Complemento = complemento
            };

            return cliente;
        }

        public ClienteDto ObterClienteDto()
        {
            Random rand = new Random();
            var cliente = new ClienteDto();

            cliente.IdCliente = (int)rand.NextInt64(1, 1000);
            cliente.Nome = rand.Next(0, 100).ToString();
            cliente.CPFCNPJ = rand.Next(0, 100).ToString();
            cliente.Telefone = rand.Next(0, 100).ToString();
            cliente.Celular = rand.Next(0, 100).ToString();
            cliente.Email = rand.Next(0, 100).ToString();

            cliente.CEP = rand.Next(0, 100).ToString();
            cliente.Logradouro = rand.Next(0, 100).ToString();
            cliente.Numero = rand.Next(0, 1020).ToString();
            cliente.Cidade = rand.Next(0, 1100).ToString();
            cliente.UF = rand.Next(0, 1003).ToString();
            cliente.Complemento = rand.Next(0, 1020).ToString();

            return cliente;
        }

    }

    [ExcludeFromCodeCoverage]
    [CollectionDefinition(nameof(ClienteDomainFixtureCollection))]
    public class ClienteDomainFixtureCollection : ICollectionFixture<ClienteDomainFixture> { 
        
        
            
    }

}
