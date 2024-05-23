using Cadastro.Clientes.Domain.Domains;
using Cadastro.Clientes.Domain.Domains.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Domain.Dto
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CEP {  get; set; }
        public string Logradouro {  get; set; }
        public string Numero {  get; set; }
        public string Cidade {  get; set; }
        public string UF {  get; set; }
        public string Complemento {  get; set; }


        public Cliente ToCliente()
        {
            var cliente = new Cliente();

            cliente.IdCliente = IdCliente;
            cliente.Nome = Nome;
            cliente.CPFCNPJ = CPFCNPJ;
            cliente.Telefone = Telefone;
            cliente.Celular = Celular;
            cliente.Email = Email;


            cliente.Endereco = new Endereco();
            cliente.Endereco.CEP = CEP;
            cliente.Endereco.Logradouro = Logradouro;
            cliente.Endereco.Numero = Numero;
            cliente.Endereco.Cidade = Cidade;
            cliente.Endereco.UF = UF;
            cliente.Endereco.Complemento = Complemento;

            return cliente;
        }
    }
}
