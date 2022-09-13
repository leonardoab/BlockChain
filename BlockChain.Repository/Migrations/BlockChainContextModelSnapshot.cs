﻿// <auto-generated />
using System;
using BlockChain.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlockChain.Repository.Migrations
{
    [DbContext(typeof(BlockChainContext))]
    partial class BlockChainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Carteira", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoCarteira")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DataVerificacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroTransacoes")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<float>("Saldo")
                        .HasColumnType("real");

                    b.Property<float>("SaldoDiario")
                        .HasColumnType("real");

                    b.Property<string>("TipoCarteira")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Carteiras", (string)null);
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Historico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarteiraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoCarteira")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataHistorico")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroTransacoes")
                        .HasColumnType("int");

                    b.Property<float>("Saldo")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.ToTable("Historicos", (string)null);
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Nft", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarteiraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdRede")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.ToTable("Nfts", (string)null);
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarteiraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoCarteiraDestino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoCarteiraOrigem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoTransacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataTrasacao")
                        .HasColumnType("datetime2");

                    b.Property<float>("Saldo")
                        .HasColumnType("real");

                    b.Property<string>("TipoTransacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.ToTable("Transacoes", (string)null);
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Carteira", b =>
                {
                    b.HasOne("BlockChain.Domain.BlockChain.Usuario", null)
                        .WithMany("Carteiras")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Historico", b =>
                {
                    b.HasOne("BlockChain.Domain.BlockChain.Carteira", null)
                        .WithMany("Historicos")
                        .HasForeignKey("CarteiraId");
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Nft", b =>
                {
                    b.HasOne("BlockChain.Domain.BlockChain.Carteira", null)
                        .WithMany("Nfts")
                        .HasForeignKey("CarteiraId");
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Transacao", b =>
                {
                    b.HasOne("BlockChain.Domain.BlockChain.Carteira", null)
                        .WithMany("Transacoes")
                        .HasForeignKey("CarteiraId");
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Usuario", b =>
                {
                    b.OwnsOne("BlockChain.Domain.BlockChain.ValueObject.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("BlockChain.Domain.BlockChain.ValueObject.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Password");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Carteira", b =>
                {
                    b.Navigation("Historicos");

                    b.Navigation("Nfts");

                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("BlockChain.Domain.BlockChain.Usuario", b =>
                {
                    b.Navigation("Carteiras");
                });
#pragma warning restore 612, 618
        }
    }
}
