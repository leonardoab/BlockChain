using BlockChain.Application.BlockChain.Dto;

namespace BlockChain.Application.BlockChain.Service
{
    public interface ITransacaoService
    {
        Task<TransacaoOutputDto> Atualizar(TransacaoInputUpdateDto dto);
        Task<TransacaoOutputDto> Criar(TransacaoInputCreateDto dto);
        Task<TransacaoOutputDto> Deletar(TransacaoInputDeleteDto dto);
        Task<List<TransacaoOutputDto>> ObterTodos();
    }
}