using BlockChain.Application.BlockChain.Dto;

namespace BlockChain.Application.BlockChain.Service
{
    public interface IHistoricoService
    {
        Task<HistoricoOutputDto> Atualizar(HistoricoInputUpdateDto dto);
        Task<HistoricoOutputDto> Criar(HistoricoInputCreateDto dto);
        Task<HistoricoOutputDto> Deletar(HistoricoInputDeleteDto dto);
        Task<List<HistoricoOutputDto>> ObterTodos();
    }
}