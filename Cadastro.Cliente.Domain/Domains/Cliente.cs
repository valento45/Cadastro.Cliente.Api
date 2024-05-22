using Cadastro.Clientes.Domain.Domains.Bases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Domain.Domains
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente()
        {
                
        }
    }
}
