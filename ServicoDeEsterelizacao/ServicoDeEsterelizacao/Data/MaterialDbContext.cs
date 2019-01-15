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

        public DbSet<ServicoDeEsterelizacao.Models.Funcao> Funcao { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Colaborador> Colaborador { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Tipo> Tipo { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Equipamento> Equipamento { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Trabalho_Posto> Trabalho_Posto { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Horario> GerarHorarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composed primary key
            modelBuilder.Entity<Trabalho_Posto>()
                .HasKey(e => new {e.Trabalho_PostoID });
            modelBuilder.Entity<Equipamento>()
                .HasKey(e => new { e.EquipamentoID});
            modelBuilder.Entity<Colaborador>()
                .HasKey(c => new { c.ColaboradorId });
            modelBuilder.Entity<Horario>()
                .HasKey(c => new { c.HorarioID });
            modelBuilder.Entity<Funcao>()
                .HasKey(c => new { c.FuncaoID });
            modelBuilder.Entity<Turno>()
                .HasKey(c => new { c.TurnoId });
            modelBuilder.Entity<Materialcs>()
                .HasKey(c => new { c.MaterialcsId });
            modelBuilder.Entity<Posto>()
                .HasKey(c => new { c.PostoId });
            modelBuilder.Entity<Regras>()
                .HasKey(c => new { c.RegrasID });
            modelBuilder.Entity<Tipo>()
               .HasKey(c => new { c.TipoID });



                      // one to many relationship
            modelBuilder.Entity<Trabalho_Posto>()
                 .HasOne(t => t.Equipamento)
                 .WithMany(e => e.Esterilizar)
                 .HasForeignKey(e => e.EquipamentoID)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Trabalho_Posto>()
                 .HasOne(t => t.Materialcs)
                 .WithMany(m => m.Esterilizar)
                 .HasForeignKey(e => e.MaterialcsID)
                 .OnDelete(DeleteBehavior.ClientSetNull); // prevent cascade delete

            modelBuilder.Entity<Trabalho_Posto>()
                .HasOne(t => t.Horario)
                .WithMany(h => h.TrabalhoPosto)
                .HasForeignKey(t => t.HorarioID)
                .OnDelete(DeleteBehavior.ClientSetNull);


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

            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Colaborador)
                .WithMany(c => c.Horario)
                .HasForeignKey(h => h.ColaboradorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Posto)
                .WithMany(p => p.Horario)
                .HasForeignKey(h => h.PostoId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Turno)
                .WithMany(t => t.Horario)
                .HasForeignKey(h => h.TurnoId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ServicoDeEsterelizacao.Models.Materialcs> Materialcs { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Horario> Horario { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Turno> Turno { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Posto> Posto { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Regras> Regras { get; set; }



    }
}
