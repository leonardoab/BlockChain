using BlockChain.Application.BlockChain.Dto;
using BlockChain.Application.BlockChain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        IUsuarioService usuarioService;

        public TokenController(IUsuarioService usuarioService)
        {

            this.usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Token(UsuarioInputAutenticacaoDto dto)
        {
            var isLogged = await usuarioService.AuthenticateUser(dto);

            if (isLogged == null || isLogged == false)
                return Unauthorized();

            return Ok(usuarioService.GenerateToken());
        }



    }
}

