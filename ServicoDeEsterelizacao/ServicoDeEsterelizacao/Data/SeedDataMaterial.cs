using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class SeedDataMaterial
    {
        private const string ROLE_ADMINISTRATOR = "Administrator";
        private const string ROLE_COLAB = "Customer";

        public static void Populate(IServiceProvider applicationServices)
        {
            using (var serviceScope = applicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<MaterialDbContext>();
                Materialcs(db);
                
               
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

        private static void SeedDirServico(MaterialDbContext db)
        {
            if (db.Materialcs.Any()) return;
            db.Materialcs.AddRange(
              new Materialcs { Nome = "Bisturi",Quantidade = 50 },
              new Materialcs { Nome = "Tesoura", Quantidade = 100 },
              new Materialcs { Nome = "Compressas", Quantidade = 500 }
              new Maquinas { Capacidade = "20",Quantidade="10"}
          );
            db.SaveChanges();
        }
        private static void Materialcs(MaterialDbContext db)
        {
            throw new NotImplementedException();
        }
    }
}
