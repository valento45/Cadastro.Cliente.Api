using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Service.Services.Interfaces
{
    public interface IClienteService
    {

        Task<Cliente> Incluir(Cliente cliente);
        Task<MessageResponse> Alterar(Cliente cliente);
        Task<MessageResponse> Excluir(int idCliente);
        Task<MessageResponse> Excluir(string email);
        Task<IEnumerable<Cliente>> GetAll(int limit = 0);
        Task<IEnumerable<Cliente>> GetByCliente(Cliente cliente);
    }
}
