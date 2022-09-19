using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
   

    public class UpdateCarteiraCommand : IRequest<UpdateCarteiraCommandResponse>
    {
        public CarteiraInputUpdateDto Carteira { get; set; }

        public UpdateCarteiraCommand(CarteiraInputUpdateDto carteira)
        {
            Carteira = carteira;

        }
    }

    public class UpdateCarteiraCommandResponse
    {
        public CarteiraOutputDto Carteira { get; set; }

        public UpdateCarteiraCommandResponse(CarteiraOutputDto carteira)
        {
            Carteira = carteira;

        }
    }
}
