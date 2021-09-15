﻿// <auto-generated />
using System;
using ApiSystemsATSM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiSystemsATSM.Migrations
{
    [DbContext(typeof(AtsmContext))]
    [Migration("20210824205746_change property corte in model concepto")]
    partial class changepropertycorteinmodelconcepto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiSystemsATSM.Models.ConceptoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Concepto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Corte")
                        .HasColumnType("int");

                    b.Property<int?>("CorteModelId")
                        .HasColumnType("int");

                    b.Property<float>("IVA")
                        .HasColumnType("real");

                    b.Property<string>("Moneda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Proveedor")
                        .HasColumnType("int");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CorteModelId");

                    b.ToTable("Concepto");
                });

            modelBuilder.Entity("ApiSystemsATSM.Models.CorteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Folio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Usuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Corte");
                });

            modelBuilder.Entity("ApiSystemsATSM.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ApiSystemsATSM.Models.ConceptoModel", b =>
                {
                    b.HasOne("ApiSystemsATSM.Models.CorteModel", null)
                        .WithMany("Conceptos")
                        .HasForeignKey("CorteModelId");
                });

            modelBuilder.Entity("ApiSystemsATSM.Models.CorteModel", b =>
                {
                    b.Navigation("Conceptos");
                });
#pragma warning restore 612, 618
        }
    }
}
