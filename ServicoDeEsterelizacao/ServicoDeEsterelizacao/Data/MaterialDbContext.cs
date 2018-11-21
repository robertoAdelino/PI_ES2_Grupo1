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
        public DbSet<ServicoDeEsterelizacao.Models.Equipamento> Equipamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Equipamento>()
                .HasKey(e => new {e.MaterialcsId });
            modelbuilder.Entity<Equipamento>().HasOne(e => e.Material)
                .WithMany(m => m.Equipamentos).HasForeignKey(e => e.MaterialcsId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelbuilder);
        }
    }
}
