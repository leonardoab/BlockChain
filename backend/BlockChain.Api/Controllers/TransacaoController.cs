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
    [Authorize]
    public class TransacaoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ICarteiraService carteiraService;
        private readonly ITransacaoService transacaoService;

        public TransacaoController(IMediator mediator, ICarteiraService carteiraService, ITransacaoService transacaoService)
        {
            this.mediator = mediator;
            this.carteiraService = carteiraService;
            this.transacaoService = transacaoService;
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

        [HttpPost]
        [Route("AssociarTransacaoCarteira")]
        public async Task<IActionResult> AssociarTransacaoCarteira(List<AssociarDto> dto)
        {

            

            return Ok(await this.carteiraService.AssociarTransacaoCarteira(dto));
            
        }

        [HttpPost]
        [Route("BuscarPorId")]
        [Authorize]
        public async Task<IActionResult> BuscarPorId(HistoricoInputDeleteDto dto)
        {
            return Ok(await transacaoService.BuscarTransacaoPorId(dto.Id));
        }





    }
}
