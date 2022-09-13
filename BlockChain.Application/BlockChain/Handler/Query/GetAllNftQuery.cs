using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Query
{
    public class GetAllNftQuery : IRequest<GetAllNftQueryResponse>
    {

    }

    public class GetAllNftQueryResponse
    {
        public IList<NftOutputDto> Nfts { get; set; }

        public GetAllNftQueryResponse(IList<NftOutputDto> nfts)
        {
            Nfts = nfts;
        }
    }
}
