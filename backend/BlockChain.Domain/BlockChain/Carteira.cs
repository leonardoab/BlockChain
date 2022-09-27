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
        public Carteira()
        {            
            Historicos = new List<Historico>();
            Transacoes = new List<Transacao>();
            Nfts = new List<Nft>();
        }

        public string CodigoCarteira { get; set; }
        public float Saldo { get; set; }
        public float SaldoDiario { get; set; }
        public int NumeroTransacoes { get; set; }
        public DateTime DataVerificacao { get; set; }
        public int Rank { get; set; }
        public string TipoCarteira { get; set; }
        public IList<Historico> Historicos { get; set; }
        public IList<Transacao> Transacoes { get; set; }
        public IList<Nft> Nfts { get; set; }

        /*public int NumeroNfts { get; set; }
        public float PatrimonioTotalDolar { get; set; }
        public float PatrimonioTotalReal { get; set; }
        public float PatrimonioTotalMafaDolar { get; set; }
        public float PatrimonioTotalMafaReal { get; set; }
        public float CotacaoDolar { get; set; }
        public float CotacaoMafa { get; set; }
        public string TipoCarteiraEmpresa { get; set; }*/


        //public string nft
    }
}

