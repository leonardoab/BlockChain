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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BlockChainContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await this.Query.Include(x => x.Carteiras).ToListAsync();
        }


        public async Task<IEnumerable<Usuario>> BuscarPorId(Guid id)
        {
            return await this.Query.Where(x => x.Id == id)
                                   .Include(x => x.Carteiras)                                   
                                   .ToListAsync();


        }


    }
}
