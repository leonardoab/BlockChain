using BlockChain.Domain.BlockChain;
using BlockChain.Domain.BlockChain.Repository;
using BlockChain.Repository.Context;
using BlockChain.Repository.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Repository.Repository
{
    public class HistoricoRepository : Repository<Historico>, IHistoricoRepository
    {
        public HistoricoRepository(BlockChainContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Historico>> BuscarPorCodCarteira(string codCarteira)
        {


            return await this.Query.Where(x => x.CodigoCarteira == codCarteira)
                                   .OrderByDescending(x => x.DataHistorico)
                                   .ToListAsync();


        }

    }
}
