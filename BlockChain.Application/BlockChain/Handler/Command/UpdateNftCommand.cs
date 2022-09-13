using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class UpdateNftCommand : IRequest<UpdateNftCommandResponse>
    {
        public NftInputUpdateDto Nft { get; set; }

        public UpdateNftCommand(NftInputUpdateDto nft)
        {
            Nft = nft;

        }
    }

    public class UpdateNftCommandResponse
    {
        public NftOutputDto Nft { get; set; }

        public UpdateNftCommandResponse(NftOutputDto nft)
        {
            Nft = nft;

        }
    }
}
