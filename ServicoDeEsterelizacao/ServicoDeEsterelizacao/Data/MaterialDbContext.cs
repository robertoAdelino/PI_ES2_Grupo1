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

        
    }
}
