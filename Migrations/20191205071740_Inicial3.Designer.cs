﻿// <auto-generated />
using System;
using MaisFII.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaisFII.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20191205071740_Inicial3")]
    partial class Inicial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MaisFII.Models.Carteira", b =>
                {
                    b.Property<int>("CarteiraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CarteiraId");

                    b.ToTable("Carteira");
                });

            modelBuilder.Entity("MaisFII.Models.Fundo", b =>
                {
                    b.Property<int>("FundoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LinkBMF")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Segmento")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("FundoId");

                    b.ToTable("Fundo");
                });

            modelBuilder.Entity("MaisFII.Models.OperacaoCompraVenda", b =>
                {
                    b.Property<int>("OperacaoCompraVendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarteiraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataOperacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("FundoId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeCota")
                        .HasColumnType("int");

                    b.Property<float>("ValorDaCota")
                        .HasColumnType("real");

                    b.Property<float>("ValorTaxaDaOperadora")
                        .HasColumnType("real");

                    b.Property<int>("tipo")
                        .HasColumnType("int");

                    b.HasKey("OperacaoCompraVendaId");

                    b.HasIndex("CarteiraId");

                    b.HasIndex("FundoId");

                    b.ToTable("OperacaoCompraVenda");
                });

            modelBuilder.Entity("MaisFII.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("Localidade")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(90)")
                        .HasMaxLength(90);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MaisFII.Models.OperacaoCompraVenda", b =>
                {
                    b.HasOne("MaisFII.Models.Carteira", "Carteira")
                        .WithMany()
                        .HasForeignKey("CarteiraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaisFII.Models.Fundo", "Fundo")
                        .WithMany()
                        .HasForeignKey("FundoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
