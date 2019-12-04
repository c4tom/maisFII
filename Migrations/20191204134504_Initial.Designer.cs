﻿// <auto-generated />
using System;
using MaisFII.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaisFII.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20191204134504_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MaisFII.Models.Carteira", b =>
                {
                    b.Property<int>("CarteiraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CarteiraId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Carteira");
                });

            modelBuilder.Entity("MaisFII.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(9) CHARACTER SET utf8mb4")
                        .HasMaxLength(9);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Localidade")
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(90) CHARACTER SET utf8mb4")
                        .HasMaxLength(90);

                    b.Property<string>("Uf")
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.HasKey("EnderecoId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("MaisFII.Models.Fundo", b =>
                {
                    b.Property<int>("FundoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LinkBMF")
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("Segmento")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("FundoId");

                    b.ToTable("Fundo");
                });

            modelBuilder.Entity("MaisFII.Models.HistoricoFundo", b =>
                {
                    b.Property<int>("HistoricoFundoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("FundoId")
                        .HasColumnType("int");

                    b.Property<float>("valor")
                        .HasColumnType("float");

                    b.HasKey("HistoricoFundoId");

                    b.HasIndex("FundoId");

                    b.ToTable("HistoricoFundo");
                });

            modelBuilder.Entity("MaisFII.Models.OperacaoCompraVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CarteiraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataOperacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FundoId")
                        .HasColumnType("int");

                    b.Property<int>("OperacaoTipo")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeCota")
                        .HasColumnType("int");

                    b.Property<float>("ValorDaCota")
                        .HasColumnType("float");

                    b.Property<float>("ValorTaxaDaOperadora")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.HasIndex("FundoId");

                    b.ToTable("OperacaoCompraVenda");
                });

            modelBuilder.Entity("MaisFII.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CarteiraId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(16) CHARACTER SET utf8mb4")
                        .HasMaxLength(16);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.HasKey("UsuarioId");

                    b.HasIndex("CarteiraId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MaisFII.Models.Carteira", b =>
                {
                    b.HasOne("MaisFII.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaisFII.Models.HistoricoFundo", b =>
                {
                    b.HasOne("MaisFII.Models.Fundo", "Fundo")
                        .WithMany()
                        .HasForeignKey("FundoId");
                });

            modelBuilder.Entity("MaisFII.Models.OperacaoCompraVenda", b =>
                {
                    b.HasOne("MaisFII.Models.Carteira", "Carteira")
                        .WithMany()
                        .HasForeignKey("CarteiraId");

                    b.HasOne("MaisFII.Models.Fundo", "Fundo")
                        .WithMany()
                        .HasForeignKey("FundoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaisFII.Models.Usuario", b =>
                {
                    b.HasOne("MaisFII.Models.Carteira", null)
                        .WithMany("UsuarioLista")
                        .HasForeignKey("CarteiraId");

                    b.HasOne("MaisFII.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });
#pragma warning restore 612, 618
        }
    }
}
