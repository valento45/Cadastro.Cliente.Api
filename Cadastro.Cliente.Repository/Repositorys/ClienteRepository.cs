using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Repository.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Repository.Repositorys
{
    public class ClienteRepository : RepositoryBase, IClienteRepository

    {
        public ClienteRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }
        public Task<bool> Incluir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Alterar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Excluir(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> GetAll(int limit = 0)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> GetByCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

       
    }
}
