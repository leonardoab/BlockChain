using BlockChain.Application.BlockChain.Dto;
using BlockChain.Application.BlockChain.Handler.Command;
using BlockChain.Application.BlockChain.Handler.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        private readonly IMediator mediator;

        public HistoricoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.mediator.Send(new GetAllHistoricoQuery()));
        }

        //[HttpPost("{idBanda}")]
        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar(HistoricoInputCreateDto dto)
        {
            var result = await this.mediator.Send(new CreateHistoricoCommand(dto));
            return Created($"{result.Historico.Id}", result.Historico);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar(HistoricoInputDeleteDto dto)
        {
            var result = await this.mediator.Send(new DeleteHistoricoCommand(dto));
            //if (result.Resultado == "Deleted") 
            return Ok(result.Resultado);
            //else return NotFound(result.Resultado);

        }

        [HttpPatch]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(HistoricoInputUpdateDto dto)
        {
            var result = await this.mediator.Send(new UpdateHistoricoCommand(dto));
            return Ok(result.Historico);

        }






    }
}
