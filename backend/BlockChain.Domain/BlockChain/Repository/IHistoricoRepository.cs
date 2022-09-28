using BlockChain.Cross.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain.Repository
{
    public interface IHistoricoRepository : IRepository<Historico>
    {
        Task<IEnumerable<Historico>> BuscarPersonalizado(string TipoCarteira, string DataInico, string DataFim, int numeroTokens);
        Task<IEnumerable<Historico>> BuscarPorCodCarteira(string codCarteira);
    }
}
