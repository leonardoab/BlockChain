using BlockChain.Application.BlockChain.Dto;
using BlockChain.Domain.BlockChain;

namespace BlockChain.Application.BlockChain.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Atualizar(UsuarioInputUpdateDto dto);
        Task<bool> AuthenticateUser(UsuarioInputAutenticacaoDto dto);
        Task<UsuarioOutputDto> Criar(UsuarioInputCreateDto dto);
        Task<UsuarioOutputDto> Deletar(UsuarioInputDeleteDto dto);
        Task<List<UsuarioOutputDto>> ObterTodos();
        Task<string> GenerateToken();
        Task<List<Usuario>> AssociarCarteiraUsuario(List<AssociarDto> dto);
        Task<Usuario> BuscarUsuarioPorId(Guid id);
    }
}