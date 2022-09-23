using BlockChain.Application.BlockChain.Dto;
using BlockChain.Application.BlockChain.Handler.Command;
using BlockChain.Application.BlockChain.Handler.Query;
using BlockChain.Domain.BlockChain.Repository;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("ListarTodos")]
        [Authorize]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.mediator.Send(new GetAllUsuarioQuery()));
        }

        //[HttpPost("{idBanda}")]
        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar(UsuarioInputCreateDto dto)
        {
           

            try
            {
                var result = await this.mediator.Send(new CreateUsuarioCommand(dto));
                if (result.Usuario == null) { return BadRequest(); }
                else { return Created($"{result.Usuario.Id}", result.Usuario); }

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

            
        }

        [HttpDelete]
        [Route("Deletar")]
        [Authorize]
        public async Task<IActionResult> Deletar(UsuarioInputDeleteDto dto)
        {
            var result = await this.mediator.Send(new DeleteUsuarioCommand(dto));
            //if (result.Resultado == "Deleted") 
            return Ok(result.Resultado);
            //else return NotFound(result.Resultado);

        }

        [HttpPatch]
        [Route("Atualizar")]
        [Authorize]
        public async Task<IActionResult> Atualizar(UsuarioInputUpdateDto dto)
        {
            var result = await this.mediator.Send(new UpdateUsuarioCommand(dto));
            return Ok(result.Usuario);

        }






    }
}
