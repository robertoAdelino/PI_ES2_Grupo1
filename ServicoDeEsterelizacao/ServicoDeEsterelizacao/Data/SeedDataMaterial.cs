using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class SeedDataMaterial
    {
        public static void Populate(MaterialDbContext db)
        {
           
                Materialcs(db);
                Colaborador(db);
                Funcao(db);
  
        }

        private static void Funcao(MaterialDbContext db)
        {

            if (db.Funcao.Any()) return;

            db.Funcao.AddRange(
                new Funcao { Nome = "Enfermeiro" },
                new Funcao { Nome = "Assistente Operacional" },
                new Funcao { Nome = "Diretor de Serviço" }
            );

            db.SaveChanges();


        }

        private static void Colaborador(MaterialDbContext db)
        {
            



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
