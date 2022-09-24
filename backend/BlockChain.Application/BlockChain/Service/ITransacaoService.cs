using BlockChain.Application.BlockChain.Dto;
using BlockChain.Domain.BlockChain;

namespace BlockChain.Application.BlockChain.Service
{
    public interface ITransacaoService
    {
        Task<TransacaoOutputDto> Atualizar(TransacaoInputUpdateDto dto);
        Task<Transacao> BuscarTransacaoPorId(Guid Id);
        Task<TransacaoOutputDto> Criar(TransacaoInputCreateDto dto);
        Task<TransacaoOutputDto> Deletar(TransacaoInputDeleteDto dto);
        Task<List<TransacaoOutputDto>> ObterTodos();
    }
}