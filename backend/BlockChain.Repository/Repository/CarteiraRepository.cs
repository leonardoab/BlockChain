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
    public class CarteiraRepository : Repository<Carteira>, ICarteiraRepository
    {
        public CarteiraRepository(BlockChainContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Carteira>> ObterTodasCarteiras()
        {
            return await this.Query.Include(x => x.Historicos)
                                   .Include(x => x.Transacoes)
                                   .Include(x => x.Nfts).OrderByDescending(x => x.Saldo)
                                   .ToListAsync();
        }

        public async Task<IEnumerable<Carteira>> BuscarPorId(Guid id)
        {


            return await this.Query.Where(x => x.Id == id)
                                   .Include(x => x.Historicos)
                                   .Include(x => x.Transacoes)
                                   .Include(x => x.Nfts)
                                   .ToListAsync();

            
        }


        public async Task<IEnumerable<Carteira>> BuscarPorCodCarteira(string codCarteira)
        {


            return await this.Query.Where(x => x.CodigoCarteira == codCarteira)
                                   .Include(x => x.Historicos)
                                   .Include(x => x.Transacoes)
                                   .Include(x => x.Nfts)
                                   .ToListAsync();


        }

        public async Task<IEnumerable<Carteira>> BuscarTodasCarteirasTodosTipos()
        {


            return await this.Query.Where(x => x.Saldo > 0)
                                   .OrderByDescending(x => x.Saldo)
                                   .ToListAsync();


        }


        public async Task<IEnumerable<Carteira>> BuscarTodasCarteirasPrivada()
        {


            return await this.Query.Where(x => x.Saldo > 0 && x.TipoCarteira.Equals("Privada"))
                                   .OrderByDescending(x => x.Saldo)
                                   .ToListAsync();


        }

        public async Task<IEnumerable<Carteira>> BuscarTodasCarteirasEmpresa()
        {


            return await this.Query.Where(x => x.Saldo > 0 && !x.TipoCarteira.Equals("Privada"))
                                   .OrderByDescending(x => x.Saldo)
                                   .ToListAsync();


        }

    }
}
