using Cadastro.Clientes.Domain.Domains;
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

    }

    [ExcludeFromCodeCoverage]
    [CollectionDefinition(nameof(ClienteDomainFixtureCollection))]
    public class ClienteDomainFixtureCollection : ICollectionFixture<ClienteDomainFixture> { 
        
        
            
    }

}
