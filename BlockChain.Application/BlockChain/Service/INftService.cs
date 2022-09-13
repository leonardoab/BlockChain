using BlockChain.Application.BlockChain.Dto;

namespace BlockChain.Application.BlockChain.Service
{
    public interface INftService
    {
        Task<NftOutputDto> Atualizar(NftInputUpdateDto dto);
        Task<NftOutputDto> Criar(NftInputCreateDto dto);
        Task<NftOutputDto> Deletar(NftInputDeleteDto dto);
        Task<List<NftOutputDto>> ObterTodos();
    }
}