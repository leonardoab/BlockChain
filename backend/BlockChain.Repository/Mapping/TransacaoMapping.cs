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

            builder.Property(x => x.Saldo);
            builder.Property(x => x.CodigoCarteiraDestino);
            builder.Property(x => x.CodigoCarteiraOrigem);

            



        }

    }
}
