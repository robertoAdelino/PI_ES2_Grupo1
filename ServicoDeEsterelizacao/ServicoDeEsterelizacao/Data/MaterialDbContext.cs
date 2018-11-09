using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServicoDeEsterelizacao.Models
{
    public class MaterialDbContext : DbContext
    {
        public MaterialDbContext (DbContextOptions<MaterialDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServicoDeEsterelizacao.Models.Materialcs> Materialcs { get; set; }
    }
}
