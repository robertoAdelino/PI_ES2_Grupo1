﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Migrations
{
    [DbContext(typeof(MaterialDbContext))]
    [Migration("20181207124436_12345")]
    partial class _12345
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Colaborador", b =>
                {
                    b.Property<int>("FuncaoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cc")
                        .IsRequired();

                    b.Property<int>("ColaboradorId");

                    b.Property<DateTime>("DataNasc");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("FuncaoID1");

                    b.Property<string>("Morada")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("FuncaoID");

                    b.HasIndex("FuncaoID1");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Equipamento", b =>
                {
                    b.Property<int>("TipoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacidade");

                    b.Property<int>("EquipamentoID");

                    b.Property<int?>("TipoID1");

                    b.HasKey("TipoID");

                    b.HasIndex("TipoID1");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Esterilizar", b =>
                {
                    b.Property<int>("MaterialcsID");

                    b.Property<int>("EquipamentoID");

                    b.Property<int>("EsterilizarID");

                    b.HasKey("MaterialcsID", "EquipamentoID");

                    b.HasIndex("EquipamentoID");

                    b.ToTable("Esterilizar");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Funcao", b =>
                {
                    b.Property<int>("FuncaoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("FuncaoID");

                    b.ToTable("Funcao");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Materialcs", b =>
                {
                    b.Property<int>("MaterialcsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Quantidade");

                    b.HasKey("MaterialcsId");

                    b.ToTable("Materialcs");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Tipo", b =>
                {
                    b.Property<int>("TipoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("TipoID");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Colaborador", b =>
                {
                    b.HasOne("ServicoDeEsterelizacao.Models.Funcao", "Funcao")
                        .WithMany("Colaborador")
                        .HasForeignKey("FuncaoID1");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Equipamento", b =>
                {
                    b.HasOne("ServicoDeEsterelizacao.Models.Tipo", "Tipo")
                        .WithMany("Equipamento")
                        .HasForeignKey("TipoID1");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Esterilizar", b =>
                {
                    b.HasOne("ServicoDeEsterelizacao.Models.Equipamento", "Equipamento")
                        .WithMany("Esterilizar")
                        .HasForeignKey("EquipamentoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServicoDeEsterelizacao.Models.Materialcs", "Materialcs")
                        .WithMany("Esterilizar")
                        .HasForeignKey("MaterialcsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}