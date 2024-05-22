using Cadastro.Clientes.Domain.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Clientes.Service.Services
{
    public class MainHttpService
    {
        public MainHttpService()
        {

        }


        public void InformarMessageOperation(string message, int statusCode, bool sucesso, ref MessageResponse messageResponse)
        {
            if (messageResponse == null)
                messageResponse = new MessageResponse();

            messageResponse.InformarMessage(message);
            messageResponse.InformarSucesso(sucesso);
            messageResponse.InformarStatusCode(statusCode);
        }
    }
}
