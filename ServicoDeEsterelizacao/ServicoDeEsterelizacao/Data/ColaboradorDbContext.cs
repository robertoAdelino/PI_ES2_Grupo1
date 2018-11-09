using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Models
{
    public class ColaboradorDbContext : DbContext
    {
        public ColaboradorDbContext (DbContextOptions<ColaboradorDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServicoDeEsterelizacao.Models.Enfermeiros> Enfermeiros { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.AssistenteOperacional> AssistenteOperacional { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.DiretorServico> DiretorServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
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

        public DbSet<ServicoDeEsterelizacao.Models.Colaborador> Colaborador { get; set; }
    }
}
