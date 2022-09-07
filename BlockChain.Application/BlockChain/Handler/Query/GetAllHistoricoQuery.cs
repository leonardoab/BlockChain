using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Query
{
    public class GetAllHistoricoQuery : IRequest<GetAllHistoricoQueryResponse>
    {

    }

    public class GetAllHistoricoQueryResponse
    {
        public IList<HistoricoOutputDto> Historicos { get; set; }

        public GetAllHistoricoQueryResponse(IList<HistoricoOutputDto> historicos)
        {
            Historicos = historicos;
        }
    }
}
