using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{    

    public class CreateHistoricoCommand : IRequest<CreateHistoricoCommandResponse>
    {
        public HistoricoInputCreateDto Historico { get; set; }

        public CreateHistoricoCommand(HistoricoInputCreateDto historico)
        {
            Historico = historico;

        }
    }

    public class CreateHistoricoCommandResponse
    {
        public HistoricoOutputDto Historico { get; set; }

        public CreateHistoricoCommandResponse(HistoricoOutputDto historico)
        {
            Historico = historico;
        }
    }
}
