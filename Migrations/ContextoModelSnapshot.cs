﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registro_Detalle6.DAL;

namespace Registro_Detalle6.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("Registro_Detalle6.Entidades.Ordenes", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdenId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("Registro_Detalle6.Entidades.OrdenesDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrdenId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrdenId");

                    b.HasIndex("ProductoId");

                    b.ToTable("OrdenesDetalle");
                });

            modelBuilder.Entity("Registro_Detalle6.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costop")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<double>("Inventario")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costop = 55.5,
                            Descripcion = "Manzana",
                            Inventario = 57.0
                        },
                        new
                        {
                            ProductoId = 2,
                            Costop = 30.949999999999999,
                            Descripcion = "Cerveza",
                            Inventario = 53.0
                        },
                        new
                        {
                            ProductoId = 3,
                            Costop = 45.0,
                            Descripcion = "Leche",
                            Inventario = 30.0
                        });
                });

            modelBuilder.Entity("Registro_Detalle6.Entidades.Suplidores", b =>
                {
                    b.Property<int>("SuplidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("SuplidorId");

                    b.ToTable("Suplidores");

                    b.HasData(
                        new
                        {
                            SuplidorId = 1,
                            Nombres = "PorVnir"
                        },
                        new
                        {
                            SuplidorId = 2,
                            Nombres = "Presidente"
                        },
                        new
                        {
                            SuplidorId = 3,
                            Nombres = "Nestle"
                        });
                });

            modelBuilder.Entity("Registro_Detalle6.Entidades.OrdenesDetalle", b =>
                {
                    b.HasOne("Registro_Detalle6.Entidades.Ordenes", null)
                        .WithMany("Detalle")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registro_Detalle6.Entidades.Productos", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
