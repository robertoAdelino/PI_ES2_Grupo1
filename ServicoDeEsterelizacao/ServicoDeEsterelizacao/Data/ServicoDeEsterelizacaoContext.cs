using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServicoDeEsterelizacao.Models
{
    public class ServicoDeEsterelizacaoContext : DbContext
    {
        public ServicoDeEsterelizacaoContext (DbContextOptions<ServicoDeEsterelizacaoContext> options)
            : base(options)
        {
        }

        public DbSet<ServicoDeEsterelizacao.Models.InfoModel> InfoModel { get; set; }
    }
}
