using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;

namespace ServicoDeEsterelizacao.Models
{
    public class EquipamentoDbContext : DbContext
    {
        public EquipamentoDbContext (DbContextOptions<EquipamentoDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServicoDeEsterelizacao.Models.Equipamento> Equipamento { get; set; }

        public DbSet<ServicoDeEsterelizacao.Models.Materialcs> Materialcs { get; set; }
    }
}
