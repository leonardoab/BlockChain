using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class DeleteTransacaoCommand : IRequest<DeleteTransacaoCommandResponse>
    {
        public TransacaoInputDeleteDto Transacao { get; set; }

        public DeleteTransacaoCommand(TransacaoInputDeleteDto transacao)
        {
            Transacao = transacao;

        }
    }

    public class DeleteTransacaoCommandResponse
    {
        public string Resultado;

        public DeleteTransacaoCommandResponse(string resultado)
        {
            Resultado = resultado;
        }
    }
}
