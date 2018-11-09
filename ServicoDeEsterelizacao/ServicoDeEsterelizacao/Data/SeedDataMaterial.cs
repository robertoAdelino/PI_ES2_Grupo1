using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class SeedDataMaterial
    {
        public static void Populate(IServiceProvider applicationServices)
        {
            using (var serviceScope = applicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<MaterialDbContext>();
                Materialcs(db);
               
            }
        }
        private static void SeedDirServico(MaterialDbContext db)
        {
            if (db.Materialcs.Any()) return;
            db.Materialcs.AddRange(
              new Materialcs { Nome = "Bisturi" },
              new Materialcs { Nome = "Tesoura" },
              new Materialcs { Nome = "Compressas" }
          );
            db.SaveChanges();
        }
        private static void Materialcs(MaterialDbContext db)
        {
            throw new NotImplementedException();
        }
    }
}
