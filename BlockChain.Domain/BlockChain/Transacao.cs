using BlockChain.Cross.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain
{
    
    public class Transacao : Entity<Guid>
    {
        public Carteira CarteiraOrigem { get; set; }
        public Carteira CarteiraDestino { get; set; }
        public DateTime DataTrasacao { get; set; }        
        public string TipoTransacao { get; set; }
        public string CodigoTransacao { get; set; }
    }
}
