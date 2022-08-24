using BlockChain.Cross.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain
{
    public class Carteira : Entity<Guid>
    {
        public string CodigoCarteira { get; set; }
        public float Saldo { get; set; }
        public int NumeroTransacoes { get; set; }
        public DateTime DataVerificacao { get; set; }
        public int Rank { get; set; }
        public string Empresa { get; set; }

    }
}
