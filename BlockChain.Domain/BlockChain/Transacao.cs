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
        public string CodigoCarteiraOrigem { get; set; }
        public string CodigoCarteiraDestino { get; set; }
        public DateTime DataTrasacao { get; set; }
        public float Saldo { get; set; }
    }
}
