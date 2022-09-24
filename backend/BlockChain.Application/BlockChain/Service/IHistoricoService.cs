using BlockChain.Application.BlockChain.Dto;
using BlockChain.Domain.BlockChain;

namespace BlockChain.Application.BlockChain.Service
{
    public interface IHistoricoService
    {
        Task<HistoricoOutputDto> Atualizar(HistoricoInputUpdateDto dto);
        Task<Historico> BuscarHistoricoPorId(Guid Id);
        Task<HistoricoOutputDto> Criar(HistoricoInputCreateDto dto);
        Task<HistoricoOutputDto> Deletar(HistoricoInputDeleteDto dto);
        Task<List<HistoricoOutputDto>> ObterTodos();
    }
}