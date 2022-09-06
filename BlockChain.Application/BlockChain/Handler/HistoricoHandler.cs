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
    public class HistoricoHandler : IRequestHandler<CreateHistoricoCommand, CreateHistoricoCommandResponse>,
                                IRequestHandler<GetAllHistoricoQuery, GetAllHistoricoQueryResponse>,
                                IRequestHandler<DeleteHistoricoCommand, DeleteHistoricoCommandResponse>,
                                IRequestHandler<UpdateHistoricoCommand, UpdateHistoricoCommandResponse>



    {
        private readonly IHistoricoService _HistoricoService;

        public HistoricoHandler(IHistoricoService HistoricoService)
        {
            _HistoricoService = HistoricoService;
        }

        public async Task<CreateHistoricoCommandResponse> Handle(CreateHistoricoCommand request, CancellationToken cancellationToken)
        {
            var result = await this._HistoricoService.Criar(request.Historico);
            return new CreateHistoricoCommandResponse(result);
        }

        public async Task<DeleteHistoricoCommandResponse> Handle(DeleteHistoricoCommand request, CancellationToken cancellationToken)
        {
            //var result = await this._HistoricoService.BuscarPorIdExclusao(request.Historico);
            //if (result == null) return new DeleteHistoricoCommandResponse("ID não Encontrado");
            //else
            // {
            var result = await this._HistoricoService.Deletar(request.Historico);
            return new DeleteHistoricoCommandResponse("Deleted");
            //}
        }

        public async Task<UpdateHistoricoCommandResponse> Handle(UpdateHistoricoCommand request, CancellationToken cancellationToken)
        {
            var result = await this._HistoricoService.Atualizar(request.Historico);
            return new UpdateHistoricoCommandResponse(result);
        }


        public async Task<GetAllHistoricoQueryResponse> Handle(GetAllHistoricoQuery request, CancellationToken cancellationToken)
        {
            var result = await this._HistoricoService.ObterTodos();
            return new GetAllHistoricoQueryResponse(result);
        }


    }
}
