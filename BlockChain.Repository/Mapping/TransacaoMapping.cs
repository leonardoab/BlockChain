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
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {

            builder.ToTable("Transacoes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
           
            builder.Property(x => x.DataTrasacao);
            builder.Property(x => x.TipoTransacao);
            builder.Property(x => x.CodigoTransacao);

            builder.OwnsOne(x => x.CarteiraDestino, p => { p.Property(f => f.Saldo).HasColumnName("SaldoDestino").IsRequired(); });
            builder.OwnsOne(x => x.CarteiraDestino, p => { p.Property(f => f.CodigoCarteira).HasColumnName("CodigoCarteiraDestino").IsRequired(); });

            builder.OwnsOne(x => x.CarteiraOrigem, p => { p.Property(f => f.Saldo).HasColumnName("SaldoOrigem").IsRequired(); });
            builder.OwnsOne(x => x.CarteiraOrigem, p => { p.Property(f => f.CodigoCarteira).HasColumnName("CodigoCarteiraOrigem").IsRequired(); });



        }

    }
}
