using BlockChain.Cross.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain.Repository
{
    public interface ICarteiraRepository : IRepository<Carteira>
    {
        Task<IEnumerable<Carteira>> BuscarPorCodCarteira(string codCarteira);
        Task<IEnumerable<Carteira>> BuscarPorId(Guid id);
        Task<IEnumerable<Carteira>> BuscarTodasCarteirasEmpresa();
        Task<IEnumerable<Carteira>> BuscarTodasCarteirasPrivada();
        Task<IEnumerable<Carteira>> BuscarTodasCarteirasTodosTipos();
        Task<IEnumerable<Carteira>> ObterTodasCarteiras();
    }
}
