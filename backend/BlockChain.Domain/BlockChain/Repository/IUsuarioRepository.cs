﻿using BlockChain.Cross.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> BuscarPorId(Guid id);
        Task<IEnumerable<Usuario>> ObterTodosUsuarios();
    }
}
