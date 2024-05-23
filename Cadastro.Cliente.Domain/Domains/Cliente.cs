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
        public string Email { get; set; }



        public Endereco Endereco { get; set; }

        public Cliente()
        {

        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(Nome);
            str.AppendLine(CPFCNPJ);
            str.AppendLine(Telefone);
            str.AppendLine(Celular);

            return str.ToString();
        }


        public bool PossuiCamposPreenchidos() =>
            !string.IsNullOrEmpty(Nome) ||
            !string.IsNullOrEmpty(CPFCNPJ) ||
            !string.IsNullOrEmpty(Telefone) ||
            !string.IsNullOrEmpty(Celular);

    }
}
