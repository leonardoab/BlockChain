using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class CreateCarteiraCommand : IRequest<CreateCarteiraCommandResponse>
    {
        public CarteiraInputCreateDto Carteira { get; set; }        

        public CreateCarteiraCommand(CarteiraInputCreateDto carteira)
        {
            Carteira = carteira;

        }
    }

    public class CreateCarteiraCommandResponse
    {
        public CarteiraOutputDto Carteira { get; set; }

        public CreateCarteiraCommandResponse(CarteiraOutputDto carteira)
        {
            Carteira = carteira;
        }
    }

}
