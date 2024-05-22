using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Repository.Repositorys.Interfaces;
using Cadastro.Clientes.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Incluir(Cliente cliente)
        {
            return await _clienteRepository.Incluir(cliente);
        }

        public async Task<bool> Alterar(Cliente cliente)
        {
            return await _clienteRepository.Alterar(cliente);
        }

        public async Task<bool> Excluir(int idCliente)
        {
            return await _clienteRepository.Excluir(idCliente);
        }

        public async Task<IEnumerable<Cliente>> GetAll(int limit = 0)
        {
            return await _clienteRepository.GetAll(limit);
        }

        public async Task<IEnumerable<Cliente>> GetByCliente(Cliente cliente)
        {
            return await _clienteRepository.GetByCliente(cliente);
        }

       
    }
}
