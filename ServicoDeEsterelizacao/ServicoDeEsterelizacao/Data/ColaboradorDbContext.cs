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

        public DbSet<ServicoDeEsterelizacao.Models.Colaborador> Colaboradores { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Horario> Horarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Colaborador>().HasOne(h => h.horario)
                .WithMany(h =>h.Colaborador).OnDelete(DeleteBehavior.ClientSetNull);


            modelbuilder.Entity<Horario>().HasMany(c =>c.Colaborador)
                .WithOne(h => h.horario).OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelbuilder);

        }
    }
}
