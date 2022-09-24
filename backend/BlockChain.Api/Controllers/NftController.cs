using BlockChain.Application.BlockChain.Dto;
using BlockChain.Application.BlockChain.Handler.Command;
using BlockChain.Application.BlockChain.Handler.Query;
using BlockChain.Application.BlockChain.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NftController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ICarteiraService carteiraService;
        private readonly INftService nftService;

        public NftController(IMediator mediator, ICarteiraService carteiraService, INftService nftService)
        {
            this.mediator = mediator;
            this.carteiraService = carteiraService;
            this.nftService = nftService;
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


        [HttpPost]
        [Route("AssociarNftCarteira")]
        public async Task<IActionResult> AssociarNftCarteira(List<AssociarDto> dto)
        {

            

            return Ok(await this.carteiraService.AssociarNftCarteira(dto));
           
        }

        [HttpPost]
        [Route("BuscarPorId")]
        [Authorize]
        public async Task<IActionResult> BuscarPorId(HistoricoInputDeleteDto dto)
        {
            return Ok(await nftService.BuscarNftPorId(dto.Id));
        }






    }
}
