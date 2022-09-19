using BlockChain.Application.BlockChain.Handler.Command;
using BlockChain.Application.BlockChain.Handler.Query;
using BlockChain.Application.BlockChain.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler
{
    public class CarteiraHandler : IRequestHandler<CreateCarteiraCommand, CreateCarteiraCommandResponse>,
                                IRequestHandler<GetAllCarteiraQuery, GetAllCarteiraQueryResponse>,
                                IRequestHandler<DeleteCarteiraCommand, DeleteCarteiraCommandResponse>,
                                IRequestHandler<UpdateCarteiraCommand, UpdateCarteiraCommandResponse>



    {
        private readonly ICarteiraService _CarteiraService;

        public CarteiraHandler(ICarteiraService CarteiraService)
        {
            _CarteiraService = CarteiraService;
        }

        public async Task<CreateCarteiraCommandResponse> Handle(CreateCarteiraCommand request, CancellationToken cancellationToken)
        {
            var result = await this._CarteiraService.Criar(request.Carteira);
            return new CreateCarteiraCommandResponse(result);
        }

        public async Task<DeleteCarteiraCommandResponse> Handle(DeleteCarteiraCommand request, CancellationToken cancellationToken)
        {
            //var result = await this._CarteiraService.BuscarPorIdExclusao(request.Carteira);
            //if (result == null) return new DeleteCarteiraCommandResponse("ID não Encontrado");
            //else
            // {
            var result = await this._CarteiraService.Deletar(request.Carteira);
            return new DeleteCarteiraCommandResponse("Deleted");
            //}
        }

        public async Task<UpdateCarteiraCommandResponse> Handle(UpdateCarteiraCommand request, CancellationToken cancellationToken)
        {
            var result = await this._CarteiraService.Atualizar(request.Carteira);
            return new UpdateCarteiraCommandResponse(result);
        }


        public async Task<GetAllCarteiraQueryResponse> Handle(GetAllCarteiraQuery request, CancellationToken cancellationToken)
        {
            var result = await this._CarteiraService.ObterTodos();
            return new GetAllCarteiraQueryResponse(result);
        }


    }
}
