using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class DeleteCarteiraCommand : IRequest<DeleteCarteiraCommandResponse>
    {
        public CarteiraInputDeleteDto Carteira { get; set; }

        public DeleteCarteiraCommand(CarteiraInputDeleteDto carteira)
        {
            Carteira = carteira;

        }
    }

    public class DeleteCarteiraCommandResponse
    {
        public string Resultado;

        public DeleteCarteiraCommandResponse(string resultado)
        {
            Resultado = resultado;
        }
    }
}
