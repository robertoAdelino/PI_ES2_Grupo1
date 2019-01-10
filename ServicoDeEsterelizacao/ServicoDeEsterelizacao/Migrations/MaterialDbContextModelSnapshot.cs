﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Migrations
{
    [DbContext(typeof(MaterialDbContext))]
    partial class MaterialDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Colaborador", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cc")
                        .IsRequired();

                    b.Property<DateTime>("DataNasc");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("FuncaoID");

                    b.Property<string>("Morada")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("ColaboradorId");

                    b.HasIndex("FuncaoID");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Equipamento", b =>
                {
                    b.Property<int>("EquipamentoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacidade");

                    b.Property<int>("TipoID");

                    b.HasKey("EquipamentoID");

                    b.HasIndex("TipoID");

                    b.ToTable("Equipamento");
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

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Horario", b =>
                {
                    b.Property<int>("HorarioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColaboradorId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("PostoId");

                    b.Property<int>("TurnoId");

                    b.HasKey("HorarioID");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("PostoId");

                    b.HasIndex("TurnoId");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Materialcs", b =>
                {
                    b.Property<int>("MaterialcsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Quantidade");

                    b.HasKey("MaterialcsId");

                    b.ToTable("Materialcs");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Posto", b =>
                {
                    b.Property<int>("PostoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("PostoId");

                    b.ToTable("Posto");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Regras", b =>
                {
                    b.Property<int>("RegrasID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("RegrasID");

                    b.ToTable("Regras");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Tipo", b =>
                {
                    b.Property<int>("TipoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("TipoID");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Trabalho_Posto", b =>
                {
                    b.Property<int>("Trabalho_PostoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataServico");

                    b.Property<int>("EquipamentoID");

                    b.Property<bool?>("Estado")
                        .IsRequired();

                    b.Property<int>("HorarioID");

                    b.Property<int>("MaterialcsID");

                    b.HasKey("Trabalho_PostoID");

                    b.HasIndex("EquipamentoID");

                    b.HasIndex("HorarioID");

                    b.HasIndex("MaterialcsID");

                    b.ToTable("Trabalho_Posto");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Turno", b =>
                {
                    b.Property<int>("TurnoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Horafim");

                    b.Property<DateTime>("Horainicio");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("TurnoId");

                    b.ToTable("Turno");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Colaborador", b =>
                {
                    b.HasOne("ServicoDeEsterelizacao.Models.Funcao", "Funcao")
                        .WithMany("Colaborador")
                        .HasForeignKey("FuncaoID");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Equipamento", b =>
                {
                    b.HasOne("ServicoDeEsterelizacao.Models.Tipo", "Tipo")
                        .WithMany("Equipamento")
                        .HasForeignKey("TipoID");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Horario", b =>
                {
                    b.HasOne("ServicoDeEsterelizacao.Models.Colaborador", "Colaborador")
                        .WithMany("Horario")
                        .HasForeignKey("ColaboradorId");

                    b.HasOne("ServicoDeEsterelizacao.Models.Posto", "Posto")
                        .WithMany("Horario")
                        .HasForeignKey("PostoId");

                    b.HasOne("ServicoDeEsterelizacao.Models.Turno", "Turno")
                        .WithMany("Horario")
                        .HasForeignKey("TurnoId");
                });

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Trabalho_Posto", b =>
                {
                    b.HasOne("ServicoDeEsterelizacao.Models.Equipamento", "Equipamento")
                        .WithMany("Esterilizar")
                        .HasForeignKey("EquipamentoID");

                    b.HasOne("ServicoDeEsterelizacao.Models.Horario", "Horario")
                        .WithMany("TrabalhoPosto")
                        .HasForeignKey("HorarioID");

                    b.HasOne("ServicoDeEsterelizacao.Models.Materialcs", "Materialcs")
                        .WithMany("Esterilizar")
                        .HasForeignKey("MaterialcsID");
                });
#pragma warning restore 612, 618
        }
    }
}
