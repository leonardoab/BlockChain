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


         public async Task<IEnumerable<Historico>> BuscarUltimaCotacao()
        {
           

            

            return await this.Query.OrderByDescending(x => x.DataHistorico).Take(1)
                                   .ToListAsync();



        }

        public async Task<IEnumerable<Historico>> BuscarPersonalizado(string TipoCarteira, string DataInico, string DataFim, int numeroTokens)
        {

            if (TipoCarteira != null && TipoCarteira.Equals("Empresa") && DataInico == null)
            {

                return await this.Query.Where(x => x.TipoCarteira != "Privada")
                                  .OrderByDescending(x => x.DataHistorico).Take(200)
                                  .ToListAsync();

            }
            else if (TipoCarteira != null && TipoCarteira.Equals("Privada") && DataInico == null)
            {

                return await this.Query.Where(x => x.TipoCarteira == "Privada")
                                  .OrderByDescending(x => x.DataHistorico).Take(200)
                                  .ToListAsync();

            }
            else if (numeroTokens != 0)
            {

                return await this.Query.Where(x => (x.Diferenca > numeroTokens && x.Diferenca > 0) || (x.Diferenca < (numeroTokens * -1)  && x.Diferenca < 0))
                                  .OrderByDescending(x => x.DataHistorico).Take(200)
                                  .ToListAsync();

            }
            else {
                return await this.Query
                                     .OrderByDescending(x => x.DataHistorico).Take(200)
                                     .ToListAsync();


            }






            
        }



        }
    }
