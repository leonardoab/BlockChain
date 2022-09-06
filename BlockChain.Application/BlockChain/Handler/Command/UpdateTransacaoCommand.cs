using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class UpdateTransacaoCommand : IRequest<UpdateTransacaoCommandResponse>
    {
        public TransacaoInputUpdateDto Transacao { get; set; }

        public UpdateTransacaoCommand(TransacaoInputUpdateDto transacao)
        {
            Transacao = transacao;

        }
    }

    public class UpdateTransacaoCommandResponse
    {
        public TransacaoOutputDto Transacao { get; set; }

        public UpdateTransacaoCommandResponse(TransacaoOutputDto transacao)
        {
            Transacao = transacao;

        }
    }
}
