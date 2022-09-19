using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class UpdateHistoricoCommand : IRequest<UpdateHistoricoCommandResponse>
    {
        public HistoricoInputUpdateDto Historico { get; set; }

        public UpdateHistoricoCommand(HistoricoInputUpdateDto historico)
        {
            Historico = historico;

        }
    }

    public class UpdateHistoricoCommandResponse
    {
        public HistoricoOutputDto Historico { get; set; }

        public UpdateHistoricoCommandResponse(HistoricoOutputDto historico)
        {
            Historico = historico;

        }
    }
}
