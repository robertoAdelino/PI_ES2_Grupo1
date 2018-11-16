﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ServicoDeEsterelizacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Data
{
    public class SeedData2
    {
        internal static void Populate(IServiceProvider applicationServices)
        {
            using (var serviceScope = applicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ColaboradorDbContext>();
                SeedColab(db);
                SeedEnfermeiro(db);
                SeedAssistenteOperacional(db);
                //SeedDirServico(db);
            }
        }

        public static async void CreateApplicationUsersAsync(UserManager<IdentityUser> userManager)
        {
            const string ADMIN_USER = "admin";
            const string ADMIN_PASSWORD = "sECRET$123";

            IdentityUser admin = await userManager.FindByNameAsync(ADMIN_USER);
            if (admin == null)
            {
                admin = new IdentityUser { UserName = ADMIN_USER };
                await userManager.CreateAsync(admin, ADMIN_PASSWORD);
            }
        }

        //private static void SeedDirServico(ColaboradorDbContext db)
        //{
        //    if (db.DiretorServico.Any()) return;
        //    db.DiretorServico.AddRange(
        //      new DiretorServico { Nome = "Antonio" },
        //      new DiretorServico { Nome = "Maria" },
        //      new DiretorServico { Nome = "Manuel" }
        //  );
        //    db.SaveChanges();
        //}
        private static void SeedAssistenteOperacional(ColaboradorDbContext db)
        {
            if (db.AssistenteOperacional.Any()) return;
            db.AssistenteOperacional.AddRange(
               new AssistenteOperacional { Nome = "Tomé" },
               new AssistenteOperacional { Nome = "José" },
               new AssistenteOperacional { Nome = "Carla" },
               new AssistenteOperacional { Nome = "Paula" },
               new AssistenteOperacional { Nome = "Hugo" },
               new AssistenteOperacional { Nome = "Olga" }

           );
            db.SaveChanges();
        }
        private static void SeedEnfermeiro(ColaboradorDbContext db)
        {
            if (db.Enfermeiros.Any()) return;
            db.Enfermeiros.AddRange(
               new Enfermeiros { Nome = "Paulo" },
               new Enfermeiros {  Nome = "Ilda" }
               /*new Enfermeiros { EnfermeirosID = 3, Nome = "Carina" },
               new Enfermeiros { EnfermeirosID = 4, Nome = "Beatriz" },
               new Enfermeiros { EnfermeirosID = 5, Nome = "Luis" },
               new Enfermeiros { EnfermeirosID = 6, Nome = "Yuri" },
               new Enfermeiros { EnfermeirosID = 7, Nome = "Mariana" },
               new Enfermeiros { EnfermeirosID = 8, Nome = "Céu" },
               new Enfermeiros { EnfermeirosID = 9, Nome = "Carolina" },
               new Enfermeiros { EnfermeirosID = 10, Nome = "Carlos" }*/
           );
            db.SaveChanges();
        }
        public static void SeedColab(ColaboradorDbContext db)
        {
           if (db.Colaborador.Any()) return;

            db.Colaborador.AddRange(

               );
            db.SaveChanges();
        }
    }
}

