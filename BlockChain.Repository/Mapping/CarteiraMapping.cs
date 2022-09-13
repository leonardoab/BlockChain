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
    public class CarteiraMapping : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {

            builder.ToTable("Carteiras");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CodigoCarteira).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Saldo);
            builder.Property(x => x.NumeroTransacoes);
            builder.Property(x => x.DataVerificacao);
            builder.Property(x => x.Rank);
            builder.Property(x => x.TipoCarteira);
            builder.Property(x => x.SaldoDiario);

            builder.HasMany(x => x.Transacoes).WithOne();
            builder.HasMany(x => x.Historicos).WithOne();
            builder.HasMany(x => x.Nfts).WithOne();
        }
    }
}
