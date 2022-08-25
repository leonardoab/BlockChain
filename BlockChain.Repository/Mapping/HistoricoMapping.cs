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
            builder.OwnsOne(x => x.HistoricoCarteira, p => { p.Property(f => f.Saldo).HasColumnName("Saldo").IsRequired(); });
            builder.OwnsOne(x => x.HistoricoCarteira, p => { p.Property(f => f.CodigoCarteira).HasColumnName("CodigoCarteira").IsRequired(); });
            builder.OwnsOne(x => x.HistoricoCarteira, p => { p.Property(f => f.NumeroTransacoes).HasColumnName("NumeroTransacoes").IsRequired(); });



        }
    }
}
