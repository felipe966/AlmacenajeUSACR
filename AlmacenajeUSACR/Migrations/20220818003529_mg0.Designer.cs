﻿// <auto-generated />
using System;
using AlmacenajeUSACR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlmacenajeUSACR.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220818003529_mg0")]
    partial class mg0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.HasSequence<int>("Codigo_cliente")
                .StartsAt(1000L);

            modelBuilder.HasSequence<int>("Codigo_transportista")
                .StartsAt(1000L);

            modelBuilder.Entity("AlmacenajeUSACR.Models.Articulo_custodia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Codigo_cliente")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_transportista")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha_ingreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_retiro")
                        .HasColumnType("datetime2");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<float>("Precio_articulo")
                        .HasColumnType("real");

                    b.Property<string>("TrackingID")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.HasKey("Id");

                    b.ToTable("Articulo_custodia");
                });

            modelBuilder.Entity("AlmacenajeUSACR.Models.Articulo_retirado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Codigo_cliente")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_transportista")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha_retiro")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackingID")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.HasKey("Id");

                    b.ToTable("Articulo_retirado");
                });

            modelBuilder.Entity("AlmacenajeUSACR.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Codigo_cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR Codigo_cliente");

                    b.Property<DateTime>("Fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre_completo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Numero_identificacion")
                        .HasMaxLength(9)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("AlmacenajeUSACR.Models.Transportista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Codigo_transportista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR Codigo_transportista");

                    b.Property<string>("Nombre_empresa")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Transportista");
                });
#pragma warning restore 612, 618
        }
    }
}