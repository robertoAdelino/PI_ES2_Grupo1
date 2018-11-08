using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Models
{
    public class ServicoDbContext : DbContext
    {
        public ServicoDbContext (DbContextOptions<ServicoDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServicoDeEsterelizacao.Models.Colaborador> Colaboradores { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Horario> Horarios { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Servico> Servicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Servico>().HasKey(s => new { s.ColaboradorID, s.HorarioID });

            modelbuilder.Entity<Servico>().HasOne(s => s.Colaborador)
                .WithMany(c => c.Servico).HasForeignKey(s => s.ColaboradorID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelbuilder.Entity<Servico>().HasOne(s => s.Horario)
                .WithMany(h => h.Servico).HasForeignKey(s => s.HorarioID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelbuilder.Entity<Colaborador>()
                .HasKey(c => new { c.AssisOperID, c.DirID, c.EnfermeiroID });

            modelbuilder.Entity<Colaborador>().HasOne(c => c.Enfermeiro).WithMany(e => e.Colaborador)
                .HasForeignKey(c => c.EnfermeiroID).OnDelete(DeleteBehavior.ClientSetNull);

            modelbuilder.Entity<Colaborador>().HasOne(c => c.AssistenteOperacional).WithMany(a => a.Colaborador)
                .HasForeignKey(c => c.AssisOperID).OnDelete(DeleteBehavior.ClientSetNull);

            modelbuilder.Entity<Colaborador>().HasOne(c => c.DirServico).WithMany(d => d.Colaborador)
                .HasForeignKey(c => c.DirID).OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelbuilder);
        }
    }
}
