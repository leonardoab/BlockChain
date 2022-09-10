﻿using BlockChain.Cross.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain.Repository
{
    public interface ICarteiraRepository : IRepository<Carteira>
    {
        Task<IEnumerable<Carteira>> ObterTodasCarteiras();
    }
}
