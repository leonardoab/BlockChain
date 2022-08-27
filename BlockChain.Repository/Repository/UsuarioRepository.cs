﻿using BlockChain.Domain.BlockChain;
using BlockChain.Domain.BlockChain.Repository;
using BlockChain.Repository.Context;
using BlockChain.Repository.Database;
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
    }
}
