using Microsoft.AspNetCore.Identity;
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
        private const string ROLE_ADMINISTRATOR = "Administrator";
        private const string ROLE_COLAB = "Colaborador";

        internal static void Populate(IServiceProvider applicationServices)
        {
            using (var serviceScope = applicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ColaboradorDbContext>();
                SeedColab(db);
                SeedEnfermeiro(db);
                SeedAssistenteOperacional(db);
                SeedDirServico(db);
            }
        }

        private static async void MakeSureRoleExistsAsync(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public static async Task CreateRolesAndUsersAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string ADMIN_USER = "admin@noemail.com";
            const string ADMIN_PASSWORD = "sECRET$123";

            MakeSureRoleExistsAsync(roleManager, ROLE_ADMINISTRATOR);
            MakeSureRoleExistsAsync(roleManager, ROLE_COLAB);

            IdentityUser admin = await userManager.FindByNameAsync(ADMIN_USER);
            if (admin == null)
            {
                admin = new IdentityUser { UserName = ADMIN_USER };
                await userManager.CreateAsync(admin, ADMIN_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(admin, ROLE_ADMINISTRATOR))
            {
                await userManager.AddToRoleAsync(admin, ROLE_ADMINISTRATOR);
            }
        }

        public static async Task CreateTestUsersAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string CUSTOMER_USER = "john@noemail.com";
            const string CUSTOMER_PASSWORD = "sECREDO$123";

            IdentityUser customer = await userManager.FindByNameAsync(CUSTOMER_USER);
            if (customer == null)
            {
                customer = new IdentityUser { UserName = CUSTOMER_USER };
                await userManager.CreateAsync(customer, CUSTOMER_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(customer, ROLE_COLAB))
            {
                await userManager.AddToRoleAsync(customer, ROLE_COLAB);
            }
        }

        private static void SeedDirServico(ColaboradorDbContext db)
        {
            if (db.DiretorServico.Any()) return;
            db.DiretorServico.AddRange(
              new DiretorServico { Nome = "Antonio" },
              new DiretorServico { Nome = "Maria" },
              new DiretorServico { Nome = "Manuel" }
          );
            db.SaveChanges();
        }
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
               new Enfermeiros { Nome = "Ilda" },
               new Enfermeiros { Nome = "Carina" },
               new Enfermeiros { Nome = "Beatriz" },
               new Enfermeiros { Nome = "Luis" },
               new Enfermeiros { Nome = "Yuri" },
               new Enfermeiros { Nome = "Mariana" },
               new Enfermeiros { Nome = "Céu" },
               new Enfermeiros { Nome = "Carolina" },
               new Enfermeiros { Nome = "Carlos" }
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

