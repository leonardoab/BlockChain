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
        public Historico(Carteira carteira)
        {
            DataHistorico = carteira.DataVerificacao;
            CodigoCarteira = carteira.CodigoCarteira;
            Saldo = carteira.Saldo;
            NumeroTransacoes = carteira.NumeroTransacoes;
        }

        public Historico()
        {

        }

        public DateTime DataHistorico { get; set; }     

        public string CodigoCarteira { get; set; }
        public float Saldo { get; set; }
        public float Diferenca { get; set; }
        public int NumeroTransacoes { get; set; }
    }
}
