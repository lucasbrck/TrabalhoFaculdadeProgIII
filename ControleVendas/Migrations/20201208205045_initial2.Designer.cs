﻿// <auto-generated />
using System;
using ControleVendas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleVendas.Migrations
{
    [DbContext(typeof(ControleVendasContext))]
    [Migration("20201208205045_initial2")]
    partial class initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ControleVendas.Models.ClienteModel", b =>
                {
                    b.Property<long?>("ClienteModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteModelId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ControleVendas.Models.PedidoModel", b =>
                {
                    b.Property<long?>("PedidoModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("ClienteModelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProdutoModelId")
                        .HasColumnType("bigint");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("PedidoModelId");

                    b.HasIndex("ClienteModelId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ControleVendas.Models.PedidoProduto", b =>
                {
                    b.Property<long?>("PedidoModelId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProdutoModelId")
                        .HasColumnType("bigint");

                    b.HasKey("PedidoModelId", "ProdutoModelId");

                    b.HasIndex("ProdutoModelId");

                    b.ToTable("PedidoProdutos");
                });

            modelBuilder.Entity("ControleVendas.Models.ProdutoModel", b =>
                {
                    b.Property<long?>("ProdutoModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecoUnit")
                        .HasColumnType("float");

                    b.HasKey("ProdutoModelId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ControleVendas.Models.PedidoModel", b =>
                {
                    b.HasOne("ControleVendas.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteModelId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ControleVendas.Models.PedidoProduto", b =>
                {
                    b.HasOne("ControleVendas.Models.PedidoModel", "PedidoModel")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("PedidoModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleVendas.Models.ProdutoModel", "ProdutoModel")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("ProdutoModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PedidoModel");

                    b.Navigation("ProdutoModel");
                });

            modelBuilder.Entity("ControleVendas.Models.PedidoModel", b =>
                {
                    b.Navigation("PedidoProdutos");
                });

            modelBuilder.Entity("ControleVendas.Models.ProdutoModel", b =>
                {
                    b.Navigation("PedidoProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}
