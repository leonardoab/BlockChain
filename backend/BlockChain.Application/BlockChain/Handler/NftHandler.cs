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
    public class NftHandler : IRequestHandler<CreateNftCommand, CreateNftCommandResponse>,
                                IRequestHandler<GetAllNftQuery, GetAllNftQueryResponse>,
                                IRequestHandler<DeleteNftCommand, DeleteNftCommandResponse>,
                                IRequestHandler<UpdateNftCommand, UpdateNftCommandResponse>



    {
        private readonly INftService _NftService;

        public NftHandler(INftService NftService)
        {
            _NftService = NftService;
        }

        public async Task<CreateNftCommandResponse> Handle(CreateNftCommand request, CancellationToken cancellationToken)
        {
            var result = await this._NftService.Criar(request.Nft);
            return new CreateNftCommandResponse(result);
        }

        public async Task<DeleteNftCommandResponse> Handle(DeleteNftCommand request, CancellationToken cancellationToken)
        {
            //var result = await this._NftService.BuscarPorIdExclusao(request.Nft);
            //if (result == null) return new DeleteNftCommandResponse("ID não Encontrado");
            //else
            // {
            var result = await this._NftService.Deletar(request.Nft);
            return new DeleteNftCommandResponse("Deleted");
            //}
        }

        public async Task<UpdateNftCommandResponse> Handle(UpdateNftCommand request, CancellationToken cancellationToken)
        {
            var result = await this._NftService.Atualizar(request.Nft);
            return new UpdateNftCommandResponse(result);
        }


        public async Task<GetAllNftQueryResponse> Handle(GetAllNftQuery request, CancellationToken cancellationToken)
        {
            var result = await this._NftService.ObterTodos();
            return new GetAllNftQueryResponse(result);
        }


    }
}
