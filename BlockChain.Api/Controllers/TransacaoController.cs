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
    public class TransacaoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransacaoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.mediator.Send(new GetAllTransacaoQuery()));
        }

        //[HttpPost("{idBanda}")]
        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar(TransacaoInputCreateDto dto)
        {
            var result = await this.mediator.Send(new CreateTransacaoCommand(dto));
            return Created($"{result.Transacao.Id}", result.Transacao);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar(TransacaoInputDeleteDto dto)
        {
            var result = await this.mediator.Send(new DeleteTransacaoCommand(dto));
            //if (result.Resultado == "Deleted") 
            return Ok(result.Resultado);
            //else return NotFound(result.Resultado);

        }

        [HttpPatch]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(TransacaoInputUpdateDto dto)
        {
            var result = await this.mediator.Send(new UpdateTransacaoCommand(dto));
            return Ok(result.Transacao);

        }






    }
}
