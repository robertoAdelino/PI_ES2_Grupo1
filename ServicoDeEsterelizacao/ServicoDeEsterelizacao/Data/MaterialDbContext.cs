using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Models
{
    public class MaterialDbContext : DbContext
    {
        public MaterialDbContext (DbContextOptions<MaterialDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServicoDeEsterelizacao.Models.Materialcs> Materialcs { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Funcao> Funcao { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Colaborador> Colaborador { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Tipo> Tipo { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Equipamento> Equipamento { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Esterilizar> Esterilizar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composed primary key
            modelBuilder.Entity<Esterilizar>()
                .HasKey(e => new { e.MaterialcsID, e.EquipamentoID });
            modelBuilder.Entity<Equipamento>()
                .HasKey(e => new { e.TipoID });
            modelBuilder.Entity<Colaborador>()
                .HasKey(c => new { c.FuncaoID });

            // one to many relationship
            modelBuilder.Entity<Esterilizar>()
                .HasOne(e => e.Equipamento)
                .WithMany(e => e.Esterilizar)
                .HasForeignKey(e => e.EquipamentoID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Esterilizar>()
                .HasOne(e => e.Materialcs)
                .WithMany(m => m.Esterilizar)
                .HasForeignKey(e => e.MaterialcsID)
                .OnDelete(DeleteBehavior.ClientSetNull); // prevent cascade delete

            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Funcao)
                .WithMany(f => f.Colaborador)
                .HasForeignKey(c => c.FuncaoID)
                .OnDelete(DeleteBehavior.ClientSetNull); // prevent cascade delete

            modelBuilder.Entity<Equipamento>()
                .HasOne(e => e.Tipo)
                .WithMany(t => t.Equipamento)
                .HasForeignKey(e => e.TipoID)
                .OnDelete(DeleteBehavior.ClientSetNull); // prevent cascade delete

            base.OnModelCreating(modelBuilder);
        }


    }
}
