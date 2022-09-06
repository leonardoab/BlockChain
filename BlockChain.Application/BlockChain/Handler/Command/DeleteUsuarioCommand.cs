using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class DeleteUsuarioCommand : IRequest<DeleteUsuarioCommandResponse>
    {
        public UsuarioInputDeleteDto Usuario { get; set; }

        public DeleteUsuarioCommand(UsuarioInputDeleteDto usuario)
        {
            Usuario = usuario;

        }
    }

    public class DeleteUsuarioCommandResponse
    {
        public string Resultado;

        public DeleteUsuarioCommandResponse(string resultado)
        {
            Resultado = resultado;
        }
    }
}
