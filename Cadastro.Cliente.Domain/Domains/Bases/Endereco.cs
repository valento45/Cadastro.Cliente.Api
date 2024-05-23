using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Domain.Domains.Bases
{
    public class Endereco
    {
        public Endereco()
        {
            
        }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
    }
}
