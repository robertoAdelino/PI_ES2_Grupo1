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
                var db = serviceScope.ServiceProvider.GetService<EquipamentoDbContext>();
                Materialcs(db);
                Equipamentos(db);
               
            }
        }

        private static void Equipamentos(EquipamentoDbContext db)
        {
            if (db.Equipamento.Any()) return;

            db.Equipamento.AddRange(
                /*new Equipamento { EquipamentoID="1",MaterialcsId="1"},
                new Equipamento { EquipamentoID="1",MaterialcsId="2"},
                new Equipamento { EquipamentoID = "2",MaterialcsId="3"}*/
            );

            db.SaveChanges();
        }

        private static void Materialcs(EquipamentoDbContext db)
        {
            if (db.Materialcs.Any()) return;
            db.Materialcs.AddRange(
              new Materialcs { Nome = "Bisturi", Quantidade = 750 },
              new Materialcs { Nome = "Tesoura", Quantidade = 250 },
              new Materialcs { Nome = "Compressas" , Quantidade = 500}
          );
            db.SaveChanges();
        }

        private static Materialcs GetMaterialIfNeed(EquipamentoDbContext db, string name)
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
