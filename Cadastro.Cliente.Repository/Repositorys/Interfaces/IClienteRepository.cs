using Cadastro.Clientes.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Repository.Repositorys.Interfaces
{   
    public interface IClienteRepository
    {

        Task<Cliente> Incluir(Cliente cliente);
        Task<bool> Alterar(Cliente cliente);
        Task<bool> Excluir(int idCliente);
        Task<bool> ExcluirPorEmail(string email);
        Task<IEnumerable<Cliente>> GetAll(int limit = 0);
        Task<IEnumerable<Cliente>> GetByCliente(Cliente cliente);

        Task<bool> ExisteCliente(int idCliente);
        Task<bool> ExisteCliente(Cliente cliente);
    }
}
