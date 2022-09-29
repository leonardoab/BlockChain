using BlockChain.Application.BlockChain.Dto;
using BlockChain.Domain.BlockChain;

namespace BlockChain.Application.BlockChain.Service
{
    public interface IHistoricoService
    {
        Task<HistoricoOutputDto> Atualizar(HistoricoInputUpdateDto dto);
        Task<Historico> BuscarHistoricoPorId(Guid Id);
        Task<List<Historico>> BuscarPorHistoricoPersonalizado(string TipoCarteira, string DataInico, string DataFim, int numeroTokens);
        Task<HistoricoOutputDto> Criar(HistoricoInputCreateDto dto);
        Task<HistoricoOutputDto> Deletar(HistoricoInputDeleteDto dto);
        Task<List<Historico>> ObterCotacao();
        Task<List<Historico>> ObterHistoricosPorCodCarteira(string codCarteira);
        Task<List<HistoricoOutputDto>> ObterTodos();
    }
}