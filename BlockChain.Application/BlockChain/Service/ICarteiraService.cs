using BlockChain.Application.BlockChain.Dto;

namespace BlockChain.Application.BlockChain.Service
{
    public interface ICarteiraService
    {
        Task<CarteiraOutputDto> Atualizar(CarteiraInputUpdateDto dto);
        Task<CarteiraOutputDto> Criar(CarteiraInputCreateDto dto);
        Task<CarteiraOutputDto> Deletar(CarteiraInputDeleteDto dto);
        Task<List<CarteiraOutputDto>> ObterTodos();
    }
}