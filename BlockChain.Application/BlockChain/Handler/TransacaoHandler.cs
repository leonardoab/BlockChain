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
    public class TransacaoHandler : IRequestHandler<CreateTransacaoCommand, CreateTransacaoCommandResponse>,
                                IRequestHandler<GetAllTransacaoQuery, GetAllTransacaoQueryResponse>,
                                IRequestHandler<DeleteTransacaoCommand, DeleteTransacaoCommandResponse>,
                                IRequestHandler<UpdateTransacaoCommand, UpdateTransacaoCommandResponse>



    {
        private readonly ITransacaoService _TransacaoService;

        public TransacaoHandler(ITransacaoService TransacaoService)
        {
            _TransacaoService = TransacaoService;
        }

        public async Task<CreateTransacaoCommandResponse> Handle(CreateTransacaoCommand request, CancellationToken cancellationToken)
        {
            var result = await this._TransacaoService.Criar(request.Transacao);
            return new CreateTransacaoCommandResponse(result);
        }

        public async Task<DeleteTransacaoCommandResponse> Handle(DeleteTransacaoCommand request, CancellationToken cancellationToken)
        {
            //var result = await this._TransacaoService.BuscarPorIdExclusao(request.Transacao);
            //if (result == null) return new DeleteTransacaoCommandResponse("ID não Encontrado");
            //else
            // {
            var result = await this._TransacaoService.Deletar(request.Transacao);
            return new DeleteTransacaoCommandResponse("Deleted");
            //}
        }

        public async Task<UpdateTransacaoCommandResponse> Handle(UpdateTransacaoCommand request, CancellationToken cancellationToken)
        {
            var result = await this._TransacaoService.Atualizar(request.Transacao);
            return new UpdateTransacaoCommandResponse(result);
        }


        public async Task<GetAllTransacaoQueryResponse> Handle(GetAllTransacaoQuery request, CancellationToken cancellationToken)
        {
            var result = await this._TransacaoService.ObterTodos();
            return new GetAllTransacaoQueryResponse(result);
        }


    }
}
