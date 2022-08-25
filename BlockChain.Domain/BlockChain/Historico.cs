using BlockChain.Cross.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain
{
    public class Historico : Entity<Guid>
    {
        public Carteira HistoricoCarteira { get; set; }       
        public DateTime DataHistorico { get; set; }
    }
}
