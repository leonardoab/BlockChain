using BlockChain.Application.BlockChain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Handler.Command
{
    public class UpdateUsuarioCommand : IRequest<UpdateUsuarioCommandResponse>
    {
        public UsuarioInputUpdateDto Usuario { get; set; }

        public UpdateUsuarioCommand(UsuarioInputUpdateDto usuario)
        {
            Usuario = usuario;

        }
    }

    public class UpdateUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public UpdateUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;

        }
    }
}
