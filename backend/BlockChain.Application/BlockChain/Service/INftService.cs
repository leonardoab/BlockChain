using BlockChain.Application.BlockChain.Dto;
using BlockChain.Domain.BlockChain;

namespace BlockChain.Application.BlockChain.Service
{
    public interface INftService
    {
        Task<NftOutputDto> Atualizar(NftInputUpdateDto dto);
        Task<Nft> BuscarNftPorId(Guid Id);
        Task<NftOutputDto> Criar(NftInputCreateDto dto);
        Task<NftOutputDto> Deletar(NftInputDeleteDto dto);
        Task<List<NftOutputDto>> ObterTodos();
    }
}