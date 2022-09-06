using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class CreateTransacaoCommand : IRequest<CreateTransacaoCommandResponse>
    {
        public TransacaoInputCreateDto Transacao { get; set; }

        public CreateTransacaoCommand(TransacaoInputCreateDto transacao)
        {
            Transacao = transacao;

        }
    }

    public class CreateTransacaoCommandResponse
    {
        public TransacaoOutputDto Transacao { get; set; }

        public CreateTransacaoCommandResponse(TransacaoOutputDto transacao)
        {
            Transacao = transacao;
        }
    }
}
