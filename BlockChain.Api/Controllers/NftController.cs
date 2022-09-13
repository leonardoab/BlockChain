using BlockChain.Application.BlockChain.Dto;
using BlockChain.Application.BlockChain.Handler.Command;
using BlockChain.Application.BlockChain.Handler.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NftController : ControllerBase
    {
        private readonly IMediator mediator;

        public NftController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.mediator.Send(new GetAllNftQuery()));
        }

        //[HttpPost("{idBanda}")]
        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar(NftInputCreateDto dto)
        {
            var result = await this.mediator.Send(new CreateNftCommand(dto));
            return Created($"{result.Nft.Id}", result.Nft);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar(NftInputDeleteDto dto)
        {
            var result = await this.mediator.Send(new DeleteNftCommand(dto));
            //if (result.Resultado == "Deleted") 
            return Ok(result.Resultado);
            //else return NotFound(result.Resultado);

        }

        [HttpPatch]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(NftInputUpdateDto dto)
        {
            var result = await this.mediator.Send(new UpdateNftCommand(dto));
            return Ok(result.Nft);

        }






    }
}
