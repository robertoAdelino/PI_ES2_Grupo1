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
                //SeedTrabalhoPosto(db);
                SeedMaterialcs(db);
                SeedColaborador(db);
                SeedFuncao(db);
                SeedPosto(db);
                SeedTurno(db);
                SeedRegra(db);
  
        }

        private static void SeedRegra(MaterialDbContext db)
        {
            if (db.Regras.Any()) return;

            db.Regras.AddRange(
                new Regras { Nome = "Noites",Descricao = "Um colaborador nao pode fazer mais de duas noites seguidas."},
                new Regras { Nome = "Balanceamento", Descricao = "Os horarios dos colaboradores devem ser balanceados alternando entre manhas, tardes e noites"},
                new Regras { Nome = "Presenca", Descricao = "O numero de enfermeiros e de assistentes operacionais deve ser balanceado durante os turnos."}
                
            );
            
            db.SaveChanges();
        }

        private static void SeedPosto(MaterialDbContext db)
        {
            if (db.Posto.Any()) return;

            db.Posto.AddRange(
                new Posto { Nome = "Descontaminação"},
                new Posto { Nome = "Texteis"},
                new Posto { Nome = "Armazem de estereis e entrega"},
                new Posto { Nome = "Inspeção"},
                new Posto { Nome = "Emabalagem e esterilização"}
            );

            db.SaveChanges();
        }

        private static void SeedTurno(MaterialDbContext db)
        {
            if (db.Turno.Any()) return;

            db.Turno.AddRange(
           //     new Turno { Nome = "MANHÃ", Horainicio = new DateTime(1, 1, 1, 8, 0, 0), Horafim = new DateTime(1, 1, 1, 16, 0, 0) },
             //  new Turno { Nome = "TARDE", Horainicio = new DateTime(1, 1, 1, 16, 0, 0), Horafim = new DateTime(1, 1, 1, 0, 0, 0) }

               );

            db.SaveChanges();
        }

        private static void SeedTipo(MaterialDbContext db)
        {
            if (db.Tipo.Any()) return;

            db.Tipo.AddRange(
                new Tipo { Nome = "Autoclave"  }, //Máquina de 'lavagem' com produtos quimicos
                new Tipo { Nome = "Descontaminador" }, // Máquina para efetuar descontaminação
                new Tipo { Nome = "Incenerador"}, //'Queima' residuos organicos dos materias
                new Tipo { Nome = "Embalador"} // Embala material já esterilizado
            );

            db.SaveChanges();
        }

       private static void SeedEquipamento(MaterialDbContext db)
       {
            if (db.Equipamento.Any()) return;

            Tipo Autoclave = GetTipoCreatingIfNeed(db, "Autoclave");
            Tipo Descontaminador = GetTipoCreatingIfNeed(db, "Descontaminador");
            Tipo Incenerador = GetTipoCreatingIfNeed(db, "Incenerador");
            Tipo Embalador = GetTipoCreatingIfNeed(db, "Embalador");

            db.Equipamento.AddRange(
                new Equipamento { TipoID = Autoclave.TipoID, Capacidade = 8000},
                new Equipamento { TipoID = Embalador.TipoID, Capacidade = 1000},
                new Equipamento { TipoID = Incenerador.TipoID, Capacidade = 12000},
                new Equipamento { TipoID = Descontaminador.TipoID, Capacidade = 10000},
                new Equipamento { TipoID = Autoclave.TipoID, Capacidade = 12000 },
                new Equipamento { TipoID = Embalador.TipoID, Capacidade = 1500 },
                new Equipamento { TipoID = Incenerador.TipoID, Capacidade = 12500 },
                new Equipamento { TipoID = Descontaminador.TipoID, Capacidade = 15000 },
                new Equipamento { TipoID = Autoclave.TipoID, Capacidade = 12250 },
                new Equipamento { TipoID = Incenerador.TipoID, Capacidade = 10500 },
                new Equipamento { TipoID = Descontaminador.TipoID, Capacidade = 13000 }
            );

            db.SaveChanges();
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

            Funcao Enfermeiro = GetFuncaoCreatingIfNeed(db, "Enfermeiro");
            Funcao AssistenteOperacional = GetFuncaoCreatingIfNeed(db, "Assistente Operacional");

            db.Colaborador.AddRange(
                       new Colaborador
                       {                            
                           Nome = "Joaquim Mendes",
                           Email = "mail@mail.com",
                           Telefone = "961234567",
                           Cc = "12345678",
                           DataNasc = new DateTime(1977, 5, 19),
                           FuncaoID = Enfermeiro.FuncaoID,
                           Morada = "rua n1, guarda",
                       },
                      new Colaborador
                      {

                          Nome = "Maria Silva",
                          Email = "mail@mail.com",
                          Telefone = "961234567",
                          Cc = "12345678",
                          DataNasc = new DateTime(1977, 5, 19),
                          FuncaoID = AssistenteOperacional.FuncaoID,
                          Morada = "rua n1, guarda",
                      },
                           
                          new Colaborador
                          {

                              Nome = "João Ramos",
                              Email = "mail@mail.com",
                              Telefone = "961234567",
                              Cc = "12345678",
                              DataNasc = new DateTime(1987, 5, 19),
                              FuncaoID = Enfermeiro.FuncaoID,
                              Morada = "rua n1, guarda",
                          },
                               new Colaborador
                               {

                                   Nome = "Ana Teixeira",
                                   Email = "mail@mail.com",
                                   Telefone = "961234567",
                                   Cc = "12345678",
                                   DataNasc = new DateTime(1977, 5, 19),
                                   FuncaoID = AssistenteOperacional.FuncaoID,
                                   Morada = "rua n1, guarda",
                               }
                   );
            db.SaveChanges();

        }


        private static Funcao GetFuncaoCreatingIfNeed(MaterialDbContext db, string Nome)
        {
            Funcao funcao = db.Funcao.SingleOrDefault(e => e.Nome == Nome);

            if (funcao == null)
            {
                funcao = new Funcao { Nome = Nome };
                db.Add(funcao);
                db.SaveChanges();
            }

            return funcao;
        }

        private static Tipo GetTipoCreatingIfNeed(MaterialDbContext db, string Nome)
        {
            Tipo tipo = db.Tipo.SingleOrDefault(t => t.Nome == Nome);

            if (tipo == null)
            {
                tipo = new Tipo { Nome = Nome };
                db.Add(tipo);
                db.SaveChanges();
            }

            return tipo;
        }
        private static Equipamento GetEquipamentoCreatingIfNeed(MaterialDbContext db, int id)
        {
            Equipamento equipamento = db.Equipamento.SingleOrDefault(t => t.EquipamentoID == id);

            if (equipamento == null)
            {
                equipamento = new Equipamento { EquipamentoID = id };
                db.Add(equipamento);
                db.SaveChanges();
            }

            return equipamento;
        }
        private static Materialcs GetMaterialCreatingIfNeed(MaterialDbContext db, string Nome)
        {
            Materialcs material = db.Materialcs.SingleOrDefault(t => t.Nome == Nome);

            if (material == null)
            {
                material = new Materialcs { Nome = Nome };
                db.Add(material);
                db.SaveChanges();
            }

            return material;
        }

        private static void SeedMaterialcs(MaterialDbContext db)
        {
            if (db.Materialcs.Any()) return;
            db.Materialcs.AddRange(
                new Materialcs { Nome = "Bisturi", Quantidade = 50 },
                new Materialcs { Nome = "Tesoura" , Quantidade = 40 },
                new Materialcs { Nome = "Compressas" , Quantidade = 500},
                new Materialcs { Nome = "Agulhas", Quantidade = 100 },
                new Materialcs { Nome = "Luvas", Quantidade = 30 },
                new Materialcs { Nome = "Gaze", Quantidade = 40 },
                new Materialcs { Nome = "Pinça", Quantidade = 10 },
                new Materialcs { Nome = "Seringas", Quantidade = 15 }
          );
            db.SaveChanges();
        }
   
    }
}
