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
    public class UsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioCommandResponse>,
                                IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>,
                                IRequestHandler<DeleteUsuarioCommand, DeleteUsuarioCommandResponse>,
                                IRequestHandler<UpdateUsuarioCommand, UpdateUsuarioCommandResponse>



    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioHandler(IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        public async Task<CreateUsuarioCommandResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._UsuarioService.Criar(request.Usuario);
            return new CreateUsuarioCommandResponse(result);
        }

        public async Task<DeleteUsuarioCommandResponse> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            //var result = await this._UsuarioService.BuscarPorIdExclusao(request.Usuario);
            //if (result == null) return new DeleteUsuarioCommandResponse("ID não Encontrado");
            //else
            // {
            var result = await this._UsuarioService.Deletar(request.Usuario);
            return new DeleteUsuarioCommandResponse("Deleted");
            //}
        }

        public async Task<UpdateUsuarioCommandResponse> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._UsuarioService.Atualizar(request.Usuario);
            return new UpdateUsuarioCommandResponse(result);
        }


        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._UsuarioService.ObterTodos();
            return new GetAllUsuarioQueryResponse(result);
        }


    }
}
