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
                Colaborador(db);
               
            }
        }

        private static void Colaborador(MaterialDbContext db)
        {
            throw new NotImplementedException();
        }

        private static void Materialcs(MaterialDbContext db)
        {
            if (db.Materialcs.Any()) return;
            db.Materialcs.AddRange(
              new Materialcs { Nome = "Bisturi", Quantidade = 50 },
              new Materialcs { Nome = "Tesoura" , Quantidade = 40 },
              new Materialcs { Nome = "Compressas" , Quantidade = 200}
          );
            db.SaveChanges();
        }

    }
}
