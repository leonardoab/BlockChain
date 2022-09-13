using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class DeleteNftCommand : IRequest<DeleteNftCommandResponse>
    {
        public NftInputDeleteDto Nft { get; set; }

        public DeleteNftCommand(NftInputDeleteDto nft)
        {
            Nft = nft;

        }
    }

    public class DeleteNftCommandResponse
    {
        public string Resultado;

        public DeleteNftCommandResponse(string resultado)
        {
            Resultado = resultado;
        }
    }
}
