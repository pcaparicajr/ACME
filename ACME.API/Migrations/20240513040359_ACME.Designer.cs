﻿// <auto-generated />
using System;
using ACME.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ACME.API.Migrations
{
    [DbContext(typeof(ACMEContext))]
    [Migration("20240513040359_ACME")]
    partial class ACME
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ACME.Models.ItensPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItensPedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdPedido = 1,
                            IdProduto = 1,
                            Quantidade = 5
                        },
                        new
                        {
                            Id = 2,
                            IdPedido = 1,
                            IdProduto = 2,
                            Quantidade = 7
                        },
                        new
                        {
                            Id = 3,
                            IdPedido = 2,
                            IdProduto = 2,
                            Quantidade = 2
                        },
                        new
                        {
                            Id = 4,
                            IdPedido = 2,
                            IdProduto = 3,
                            Quantidade = 4
                        });
                });

            modelBuilder.Entity("ACME.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset?>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCriacao = new DateTimeOffset(new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)),
                            EmailCliente = "Maria@gmail.com",
                            NomeCliente = "Maria",
                            Pago = true
                        },
                        new
                        {
                            Id = 2,
                            DataCriacao = new DateTimeOffset(new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)),
                            EmailCliente = "Josegmail.com",
                            NomeCliente = "Jose",
                            Pago = true
                        });
                });

            modelBuilder.Entity("ACME.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomeProduto = "Martelo",
                            Valor = 10m
                        },
                        new
                        {
                            Id = 2,
                            NomeProduto = "Serrote",
                            Valor = 20m
                        },
                        new
                        {
                            Id = 3,
                            NomeProduto = "Prego",
                            Valor = 3m
                        });
                });

            modelBuilder.Entity("ACME.Models.ItensPedido", b =>
                {
                    b.HasOne("ACME.Models.Pedido", "Pedido")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACME.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ACME.Models.Pedido", b =>
                {
                    b.Navigation("ItensPedidos");
                });
#pragma warning restore 612, 618
        }
    }
}