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
            if (db.Colaborador.Any()) return;
            db.Colaborador.AddRange(
               new Colaborador { Nome = "Paulo",Funcao = "Enfermeiro", Telefone="123456789", Morada="Rua 1" , Filhos= true, Email= "Email@email.com"  },
               new Colaborador { Nome = "Ilda", Funcao = "Assistente Operacional", Telefone = "123456789", Morada = "Rua 1", Filhos = true, Email = "Email@email.com" },
               new Colaborador { Nome = "Carina", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1", Filhos = true, Email = "Email@email.com" },
               new Colaborador { Nome = "Beatriz", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1", Filhos = false, Email = "Email@email.com" },
               new Colaborador { Nome = "Luis", Funcao = "Assistente Operacional", Telefone = "123456789", Morada = "Rua 1", Filhos = true, Email = "Email@email.com" },
               new Colaborador { Nome = "Yuri", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1", Filhos = false, Email = "Email@email.com" },
               new Colaborador { Nome = "Mariana", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1", Filhos = true, Email = "Email@email.com" },
               new Colaborador { Nome = "Céu", Funcao = "Assistente Operacional", Telefone = "123456789", Morada = "Rua 1", Filhos = true, Email = "Email@email.com" },
               new Colaborador { Nome = "Carolina", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1", Filhos = false, Email = "Email@email.com" },
               new Colaborador { Nome = "Carlos", Funcao = "Diretor de Serviço", Telefone = "123456789", Morada = "Rua 1", Filhos = true, Email = "Email@email.com" }
           );
            db.SaveChanges();



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
