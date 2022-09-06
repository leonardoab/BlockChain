using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Query
{
    public class GetAllCarteiraQuery : IRequest<GetAllCarteiraQueryResponse>
    {

    }

    public class GetAllCarteiraQueryResponse
    {
        public IList<CarteiraOutputDto> Playlists { get; set; }

        public GetAllCarteiraQueryResponse(IList<CarteiraOutputDto> playlists)
        {
            Playlists = playlists;
        }
    }
}
