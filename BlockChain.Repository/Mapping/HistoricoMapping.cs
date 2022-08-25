using BlockChain.Domain.BlockChain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Repository.Mapping
{
    public class HistoricoMapping : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {

            builder.ToTable("Historicos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DataHistorico);

            builder.Property(x => x.Saldo);
            builder.Property(x => x.CodigoCarteira);
            builder.Property(x => x.NumeroTransacoes);




        }
    }
}
