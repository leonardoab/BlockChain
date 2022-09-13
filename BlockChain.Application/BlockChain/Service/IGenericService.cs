namespace BlockChain.Application.BlockChain.Service
{
    public interface IGenericService
    {
        Task<IList<string>> BuscarTabela(string url);
        Task<IList<string>> ConverterLinhaEmCampos(string listaTabela);
    }
}