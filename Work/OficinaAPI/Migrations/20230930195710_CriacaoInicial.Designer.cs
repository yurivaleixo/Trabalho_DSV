﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhaAPI.Data;

#nullable disable

namespace MinhaAPI.Migrations
{
    [DbContext(typeof(LockheedDbContext))]
    [Migration("20230930195710_CriacaoInicial")]
    partial class CriacaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("MinhaAPI.Models.Carro", b =>
                {
                    b.Property<int?>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .HasColumnType("TEXT");

                    b.HasKey("CarroId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("MinhaAPI.Models.CheckList", b =>
                {
                    b.Property<int?>("CheckListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CarroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NotaFiscalServicoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrdemServico")
                        .HasColumnType("TEXT");

                    b.HasKey("CheckListId");

                    b.HasIndex("CarroId");

                    b.HasIndex("NotaFiscalServicoId");

                    b.ToTable("CheckList");
                });

            modelBuilder.Entity("MinhaAPI.Models.CheckListPeca", b =>
                {
                    b.Property<int?>("CheckListPecaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CheckListId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NotaFiscalPecaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NotaFiscalServicoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PecaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CheckListPecaId");

                    b.HasIndex("CheckListId");

                    b.HasIndex("NotaFiscalPecaId");

                    b.HasIndex("NotaFiscalServicoId");

                    b.HasIndex("PecaId");

                    b.ToTable("CheckListPeca");
                });

            modelBuilder.Entity("MinhaAPI.Models.Cliente", b =>
                {
                    b.Property<int?>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MinhaAPI.Models.NotaFiscalPeca", b =>
                {
                    b.Property<int?>("NotaFiscaPecalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumNota")
                        .HasColumnType("TEXT");

                    b.Property<float?>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("NotaFiscaPecalId");

                    b.ToTable("NotaFiscalPeca");
                });

            modelBuilder.Entity("MinhaAPI.Models.NotaFiscalServico", b =>
                {
                    b.Property<int?>("NotaFiscalServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumNota")
                        .HasColumnType("TEXT");

                    b.Property<float?>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("NotaFiscalServicoId");

                    b.ToTable("NotaFiscalServico");
                });

            modelBuilder.Entity("MinhaAPI.Models.Peca", b =>
                {
                    b.Property<int?>("PecaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fornecedor")
                        .HasColumnType("TEXT");

                    b.Property<float?>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("PecaId");

                    b.ToTable("Peca");
                });

            modelBuilder.Entity("MinhaAPI.Models.Carro", b =>
                {
                    b.HasOne("MinhaAPI.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MinhaAPI.Models.CheckList", b =>
                {
                    b.HasOne("MinhaAPI.Models.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId");

                    b.HasOne("MinhaAPI.Models.NotaFiscalServico", "NotaFiscalServico")
                        .WithMany()
                        .HasForeignKey("NotaFiscalServicoId");

                    b.Navigation("Carro");

                    b.Navigation("NotaFiscalServico");
                });

            modelBuilder.Entity("MinhaAPI.Models.CheckListPeca", b =>
                {
                    b.HasOne("MinhaAPI.Models.CheckList", "CheckList")
                        .WithMany()
                        .HasForeignKey("CheckListId");

                    b.HasOne("MinhaAPI.Models.NotaFiscalPeca", "NotaFiscalPeca")
                        .WithMany()
                        .HasForeignKey("NotaFiscalPecaId");

                    b.HasOne("MinhaAPI.Models.NotaFiscalServico", "NotaFiscalServico")
                        .WithMany()
                        .HasForeignKey("NotaFiscalServicoId");

                    b.HasOne("MinhaAPI.Models.Peca", "Peca")
                        .WithMany()
                        .HasForeignKey("PecaId");

                    b.Navigation("CheckList");

                    b.Navigation("NotaFiscalPeca");

                    b.Navigation("NotaFiscalServico");

                    b.Navigation("Peca");
                });
#pragma warning restore 612, 618
        }
    }
}
