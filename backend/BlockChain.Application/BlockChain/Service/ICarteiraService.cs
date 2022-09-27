using BlockChain.Application.BlockChain.Dto;
using BlockChain.Domain.BlockChain;

namespace BlockChain.Application.BlockChain.Service
{
    public interface ICarteiraService
    {
        Task<CarteiraOutputDto> Atualizar(CarteiraInputUpdateDto dto);
        Task<CarteiraOutputDto> Criar(CarteiraInputCreateDto dto);
        Task<CarteiraOutputDto> Deletar(CarteiraInputDeleteDto dto);
        Task<List<CarteiraOutputDto>> ObterTodos();        
        Task<string> AtualizarCarteiras();
        Task<List<Carteira>> AssociarHistoricoCarteira(List<AssociarDto> dto);
        Task<Carteira> BuscarCarteiraPorCodCarteira(string codCarteira);
        Task<Carteira> BuscarCarteiraPorId(Guid Id);
        Task<List<Carteira>> AssociarTransacaoCarteira(List<AssociarDto> dto);
        Task<List<Carteira>> AssociarNftCarteira(List<AssociarDto> dto);
        Task<List<Carteira>> BuscarTodasCarteirasEmpresa();
        Task<List<Carteira>> BuscarTodasCarteirasPrivada();
        Task<List<Carteira>> BuscarTodasCarteirasTodosTipos();
    }
}