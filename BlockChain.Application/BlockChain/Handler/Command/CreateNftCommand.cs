using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class CreateNftCommand : IRequest<CreateNftCommandResponse>
    {
        public NftInputCreateDto Nft { get; set; }

        public CreateNftCommand(NftInputCreateDto nft)
        {
            Nft = nft;

        }
    }

    public class CreateNftCommandResponse
    {
        public NftOutputDto Nft { get; set; }

        public CreateNftCommandResponse(NftOutputDto nft)
        {
            Nft = nft;
        }
    }
}
