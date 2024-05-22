using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Domain.Responses;
using Cadastro.Clientes.Repository.Repositorys.Interfaces;
using Cadastro.Clientes.Service.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Service.Services
{
    public class ClienteService : MainHttpService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository) : base()
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Incluir(Cliente cliente)
        {
            return await _clienteRepository.Incluir(cliente);
        }

        public async Task<MessageResponse> Alterar(Cliente cliente)
        {
            MessageResponse messageResponse = new MessageResponse();
            var result =  await _clienteRepository.Alterar(cliente);

            if (result)            
                base.InformarMessageOperation("Dados atualizados com sucesso",
                   (int)HttpStatusCode.OK, result, ref messageResponse);
            
            else            
                base.InformarMessageOperation("Não foi possível atualizar os dados do cliente, tente mais tarde.",
                   (int)HttpStatusCode.InternalServerError, result, ref messageResponse);
            

            return messageResponse;
        }

        public async Task<MessageResponse> Excluir(int idCliente)
        {
            MessageResponse messageResponse = new MessageResponse();

          
            if (!await _clienteRepository.ExisteCliente(idCliente))
            {
                base.InformarMessageOperation("Não existe nenhum cliente com o Id informado para exclusão.",
                    (int)HttpStatusCode.BadRequest, false, ref messageResponse);   
                return messageResponse;
            }
            
            
            var result = await _clienteRepository.Excluir(idCliente);

            if (result)            
                base.InformarMessageOperation("Cliente excluído com sucesso",
                   (int)HttpStatusCode.OK, result, ref messageResponse);               
            
            else            
                base.InformarMessageOperation("Não foi possível excluir o cliente, tente mais tarde.",
                   (int)HttpStatusCode.InternalServerError, result, ref messageResponse);
            
            return messageResponse;
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
