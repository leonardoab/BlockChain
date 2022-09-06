using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Query
{
    public class GetAllTransacaoQuery : IRequest<GetAllTransacaoQueryResponse>
    {

    }

    public class GetAllTransacaoQueryResponse
    {
        public IList<TransacaoOutputDto> Playlists { get; set; }

        public GetAllTransacaoQueryResponse(IList<TransacaoOutputDto> playlists)
        {
            Playlists = playlists;
        }
    }
}
