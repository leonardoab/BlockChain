using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
   
    public class DeleteHistoricoCommand : IRequest<DeleteHistoricoCommandResponse>
    {
        public HistoricoInputDeleteDto Historico { get; set; }

        public DeleteHistoricoCommand(HistoricoInputDeleteDto historico)
        {
            Historico = historico;

        }
    }

    public class DeleteHistoricoCommandResponse
    {
        public string Resultado;

        public DeleteHistoricoCommandResponse(string resultado)
        {
            Resultado = resultado;
        }
    }
}
