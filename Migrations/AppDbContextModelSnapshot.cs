﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nydus2._0.Db;

#nullable disable

namespace Nydus2._0.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Nydus2._0.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CBO")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DescricaoAtividades")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Nydus2._0.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataAdmissao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataDemissao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("Nydus2._0.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Nydus2._0.Models.HistoricoCargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CargoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataInicioVigencia")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("HistoricoCargos");
                });

            modelBuilder.Entity("Nydus2._0.Models.HistoricoCargo", b =>
                {
                    b.HasOne("Nydus2._0.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nydus2._0.Models.Colaborador", "Colaborador")
                        .WithMany("HistoricoCargos")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("Nydus2._0.Models.Colaborador", b =>
                {
                    b.Navigation("HistoricoCargos");
                });
#pragma warning restore 612, 618
        }
    }
}