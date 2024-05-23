using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Cadastro.Clientes.Api.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    [ExcludeFromCodeCoverage]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpPost]
        [Route("CadastrarCliente")]
        public async Task<IActionResult> CadastrarCliente(Cliente cliente)
        {
            return Ok(await _clienteService.Incluir(cliente));
        }


        [HttpPut]
        [Route("AtualizarCliente")]
        public async Task<IActionResult> AtualizarCliente(Cliente cliente)
        {
            return Ok(await _clienteService.Alterar(cliente));
        }


        [HttpPost]
        [Route("ExcluirCliente")]
        public async Task<IActionResult> ExcluirCliente(int idCliente)
        {
            return Ok(await _clienteService.Excluir(idCliente));
        }



        [HttpGet]
        [Route("ObterTodos")]
        public async Task<IActionResult> GetAll(int limiteBusca)
        {
            return Ok(await _clienteService.GetAll(limiteBusca));
        }

        [HttpPost]
        [Route("ObterPorDadosCliente")]
        public async Task<IActionResult> ObterPorDadosCliente(Cliente dadosCliente)
        {
            return Ok(await _clienteService.GetByCliente(dadosCliente));
        }
    }
}
