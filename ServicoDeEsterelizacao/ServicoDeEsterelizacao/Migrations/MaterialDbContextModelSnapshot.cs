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

            modelBuilder.Entity("ServicoDeEsterelizacao.Models.Colaborador", b =>
                {
                    b.HasOne("ServicoDeEsterelizacao.Models.Funcao", "Funcao")
                        .WithMany("Colaborador")
                        .HasForeignKey("FuncaoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
