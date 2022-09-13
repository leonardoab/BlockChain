using BlockChain.Cross.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain
{
    public class Nft : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Rank { get; set; }
    }
}
