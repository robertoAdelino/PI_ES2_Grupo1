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

        public static void Populate(MaterialDbContext db)
        {
                SeedEquipamento(db);
                SeedTipo(db);
                //SeedEsterilizar(db);
                SeedMaterialcs(db);
                SeedColaborador(db);
                SeedFuncao(db);
  
        }

        private static void SeedTipo(MaterialDbContext db)
        {
            if (db.Tipo.Any()) return;

            db.Tipo.AddRange(
                new Tipo { Nome = "Autoclave"  },//Máquina de 'lavagem' com produtos quimicos
                new Tipo { Nome = "Descontaminador" }, // Máquina para efetuar descontaminação
                new Tipo { Nome = "Incenerador"} //'Queima' residuos organicos dos materias
            );
        }

        private static void SeedEquipamento(MaterialDbContext db)
        {
            if (db.Equipamento.Any()) return;

            db.Equipamento.AddRange(
                new Equipamento { EquipamentoID= 1,TipoID = 1,Capacidade = 1000},
                new Equipamento { EquipamentoID = 2 , TipoID = 1, Capacidade = 1500}
                );
        }

        /*private static async void MakeSureRoleExistsAsync(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public static async Task CreateRolesAndUsersAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string ADMIN_USER = "admin@gmail.com";
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
            const string CUSTOMER_USER = "john@gmail.com";
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
        }*/

        private static void SeedFuncao(MaterialDbContext db)
        {

            if (db.Funcao.Any()) return;

            db.Funcao.AddRange(
                new Funcao { Nome = "Enfermeiro" },
                new Funcao { Nome = "Assistente Operacional" },
                new Funcao { Nome = "Diretor de Serviço" }
            );

            db.SaveChanges();
       }

        private static void SeedColaborador(MaterialDbContext db)
        {
            if (db.Colaborador.Any()) return;
            db.Colaborador.AddRange(
               new Colaborador { Nome = "Paulo",Funcao = "Enfermeiro", Telefone="123456789", Morada="Rua 1" ,  Email= "Email@email.com"  },
               new Colaborador { Nome = "Ilda", Funcao = "Assistente Operacional", Telefone = "123456789", Morada = "Rua 1", Email = "Email@email.com" },
               new Colaborador { Nome = "Carina", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1",  Email = "Email@email.com" },
               new Colaborador { Nome = "Beatriz", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1",  Email = "Email@email.com" },
               new Colaborador { Nome = "Luis", Funcao = "Assistente Operacional", Telefone = "123456789", Morada = "Rua 1", Email = "Email@email.com" },
               new Colaborador { Nome = "Yuri", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1",  Email = "Email@email.com" },
               new Colaborador { Nome = "Mariana", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1",  Email = "Email@email.com" },
               new Colaborador { Nome = "Céu", Funcao = "Assistente Operacional", Telefone = "123456789", Morada = "Rua 1",  Email = "Email@email.com" },
               new Colaborador { Nome = "Carolina", Funcao = "Enfermeiro", Telefone = "123456789", Morada = "Rua 1",  Email = "Email@email.com" },
               new Colaborador { Nome = "Carlos", Funcao = "Diretor de Serviço", Telefone = "123456789", Morada = "Rua 1",  Email = "Email@email.com" }
           );
            db.SaveChanges();
        }

        private static void SeedMaterialcs(MaterialDbContext db)
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
