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
    public class CarteiraController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarteiraController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.mediator.Send(new GetAllCarteiraQuery()));
        }

        //[HttpPost("{idBanda}")]
        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Criar(CarteiraInputCreateDto dto)
        {
            var result = await this.mediator.Send(new CreateCarteiraCommand(dto));
            return Created($"{result.Carteira.Id}", result.Carteira);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar(CarteiraInputDeleteDto dto)
        {
            var result = await this.mediator.Send(new DeleteCarteiraCommand(dto));
            //if (result.Resultado == "Deleted") 
            return Ok(result.Resultado);
            //else return NotFound(result.Resultado);

        }

        [HttpPatch]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(CarteiraInputUpdateDto dto)
        {
            var result = await this.mediator.Send(new UpdateCarteiraCommand(dto));
            return Ok(result.Carteira);

        }






    }
}
