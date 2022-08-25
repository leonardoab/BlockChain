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
        
        public DateTime DataTrasacao { get; set; }        
        public string TipoTransacao { get; set; }
        public string CodigoTransacao { get; set; }

        public string CodigoCarteiraOrigem { get; set; }
        public string CodigoCarteiraDestino { get; set; }
        public float Saldo { get; set; }
        
    }
}
