using BlockChain.Application.BlockChain.Dto;
using BlockChain.Application.BlockChain.Handler.Command;
using BlockChain.Application.BlockChain.Handler.Query;
using BlockChain.Application.BlockChain.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CarteiraController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ICarteiraService carteiraService;
        private readonly IUsuarioService usuarioService;

        public CarteiraController(IMediator mediator, ICarteiraService carteiraService, IUsuarioService usuarioService)
        {
            this.mediator = mediator;
            this.carteiraService = carteiraService;
            this.usuarioService = usuarioService;
        }



        [HttpGet]
        [Route("AtualizarCarteiras")]
        public async Task<IActionResult> AtualizarCarteiras()
        {
            return Ok(await this.carteiraService.AtualizarCarteiras());

        }

        [HttpGet]
        [Route("ListarTodos")]
        [Authorize]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await this.mediator.Send(new GetAllCarteiraQuery()));
        }

        //[HttpPost("{idBanda}")]
        [HttpPost]
        [Route("Criar")]
        [Authorize]
        public async Task<IActionResult> Criar(CarteiraInputCreateDto dto)
        {
            var result = await this.mediator.Send(new CreateCarteiraCommand(dto));
            return Created($"{result.Carteira.Id}", result.Carteira);
        }

        [HttpDelete]
        [Route("Deletar")]
        [Authorize]
        public async Task<IActionResult> Deletar(CarteiraInputDeleteDto dto)
        {
            var result = await this.mediator.Send(new DeleteCarteiraCommand(dto));
            //if (result.Resultado == "Deleted") 
            return Ok(result.Resultado);
            //else return NotFound(result.Resultado);

        }

        [HttpPatch]
        [Route("Atualizar")]
        [Authorize]
        public async Task<IActionResult> Atualizar(CarteiraInputUpdateDto dto)
        {
            var result = await this.mediator.Send(new UpdateCarteiraCommand(dto));
            return Ok(result.Carteira);

        }



        [HttpPost]
        [Route("BuscarPorId")]
        [Authorize]
        public async Task<IActionResult> BuscarPorId(CarteiraInputDeleteDto dto)
        {            
            return Ok(await carteiraService.BuscarCarteiraPorId(dto.Id));
        }


        [HttpPost]
        [Route("BuscarPorCodCarteira")]
        [Authorize]
        public async Task<IActionResult> BuscarPorCodCarteira(string codCarteira)
        {
            return Ok(await carteiraService.BuscarCarteiraPorCodCarteira(codCarteira));
        }



        [HttpPost]
        [Route("AssociarCarteiraUsuario")]
        public async Task<IActionResult> AssociarCarteiraUsuario(List<AssociarDto> dto)
        {
            return Ok(await this.usuarioService.AssociarCarteiraUsuario(dto));

        }

        



    }
}
