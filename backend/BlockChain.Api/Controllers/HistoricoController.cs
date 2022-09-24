﻿using BlockChain.Application.BlockChain.Dto;
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
    public class HistoricoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ICarteiraService carteiraService;
        private readonly IHistoricoService historicoService;

        public HistoricoController(IMediator mediator, ICarteiraService carteiraService, IHistoricoService historicoService)
        {
            this.mediator = mediator;
            this.carteiraService = carteiraService;
            this.historicoService = historicoService;
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

        [HttpPost]
        [Route("AssociarHistoricoCarteira")]
        public async Task<IActionResult> AssociarHistoricoCarteira(List<AssociarDto> dto)
        {

            

            return Ok(await this.carteiraService.AssociarHistoricoCarteira(dto));
            
        }


        [HttpPost]
        [Route("BuscarPorId")]
        [Authorize]
        public async Task<IActionResult> BuscarPorId(HistoricoInputDeleteDto dto)
        {
            return Ok(await historicoService.BuscarHistoricoPorId(dto.Id));
        }




    }
}
