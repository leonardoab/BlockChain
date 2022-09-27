namespace BlockChain.Application.BlockChain.Service
{
    public interface IGenericService
    {
        Task<float> BuscarCotacaoMafaDolar();
        Task<float> BuscarCotacaoMafaReal();
        Task<IList<string>> BuscarTabela(string url);
        Task<IList<string>> ConverterLinhaEmCampos(string listaTabela);
    }
}