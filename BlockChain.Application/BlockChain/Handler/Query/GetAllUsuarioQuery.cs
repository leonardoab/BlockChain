using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Query
{
    public class GetAllUsuarioQuery : IRequest<GetAllUsuarioQueryResponse>
    {

    }

    public class GetAllUsuarioQueryResponse
    {
        public IList<UsuarioOutputDto> Playlists { get; set; }

        public GetAllUsuarioQueryResponse(IList<UsuarioOutputDto> playlists)
        {
            Playlists = playlists;
        }
    }
}
