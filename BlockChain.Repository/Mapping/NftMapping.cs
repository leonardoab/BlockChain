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
    public class NftMapping : IEntityTypeConfiguration<Nft>
    {
        public void Configure(EntityTypeBuilder<Nft> builder)
        {

            builder.ToTable("Nfts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasMaxLength(200);
            builder.Property(x => x.Imagem).IsRequired();
            builder.Property(x => x.Rank);
            builder.Property(x => x.IdRede);



        }
    }
}
