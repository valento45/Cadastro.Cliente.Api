using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Domain.Responses
{
    public class MessageResponse
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public bool Sucesso { get; private set; }

        public MessageResponse()
        {
            
        }
      

        public void InformarStatusCode(int statusCode)
        {
            StatusCode = statusCode;
        }
        public void InformarMessage(string message)
        {
            Message = message;
        }

        public void InformarSucesso(bool sucesso)
        {
            Sucesso = sucesso;
        }


    }
}
