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
                Equipamentos(db);
               
            }
        }

        private static void Equipamentos(MaterialDbContext db)
        {
            if (db.Equipamento.Any()) return;

            db.Equipamento.AddRange(

            );

            db.SaveChanges();
        }

        private static void Materialcs(MaterialDbContext db)
        {
            if (db.Materialcs.Any()) return;
            db.Materialcs.AddRange(
              new Materialcs { Nome = "Bisturi", Quantidade = 750 },
              new Materialcs { Nome = "Tesoura", Quantidade = 250 },
              new Materialcs { Nome = "Compressas" , Quantidade = 500}
          );
            db.SaveChanges();
        }

        private static Materialcs GetMaterialIfNeed(MaterialDbContext db, string name)
        {
            Materialcs material = db.Materialcs.SingleOrDefault(m => m.Nome == name);

            if (material == null)
            {
                material = new Materialcs { Nome = name };
                db.Add(material);
                db.SaveChanges();
            }

            return material;
        }
    }
}
