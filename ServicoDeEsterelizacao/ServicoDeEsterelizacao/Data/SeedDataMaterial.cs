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
                SeedTrabalhoPosto(db);
                SeedMaterialcs(db);
                SeedColaborador(db);
                SeedFuncao(db);
                SeedPosto(db);
                SeedTurno(db);
                SeedRegra(db);
  
        }

        private static void SeedTrabalhoPosto(MaterialDbContext db)
        {
            if (db.Trabalho_Posto.Any()) return;
            Horario horario = GetHorarioCreatingIfNeed(db,1);
            Equipamento Autoclave = GetEquipamentoCreatingIfNeed(db,1);
            Materialcs Bisturi = GetMaterialCreatingIfNeed(db, "Bisturi");

            db.Trabalho_Posto.AddRange(
                new Trabalho_Posto { Estado= "Finalizado",MaterialcsID=Bisturi.MaterialcsId,EquipamentoID = Autoclave.EquipamentoID, DataServico = new DateTime(2019, 1, 22), HorarioID = horario.HorarioID }

            );

            db.SaveChanges();
        }
    

        private static void SeedRegra(MaterialDbContext db)
        {
            if (db.Regras.Any()) return;

            db.Regras.AddRange(
                new Regras { Nome = "Noites",Descricao = "Um colaborador nao pode fazer mais de duas noites seguidas."},
                new Regras { Nome = "Balanceamento", Descricao = "Os horarios dos colaboradores devem ser balanceados alternando entre manhas, tardes e noites"},
                new Regras { Nome = "Presenca", Descricao = "O numero de enfermeiros e de assistentes operacionais deve ser balanceado durante os turnos."},
                new Regras { Nome = "Integração", Descricao = "Caso exista algum colaborador que esteja em regime de integração, será acompanhado por um colaborador mais velho do serviço (anos de serviço)."},
                new Regras { Nome = "Substituição do cargo", Descricao = "Caso o diretor de serviço não se encontra no serviço durante o turno, o enfermeiro mais velho (anos de serviço) que esteja em serviço, desempenha os cargos do diretor de serviço"},
                new Regras { Nome = "Postos", Descricao = "Caso não existam assistentes operacionais suficientes naquele turno para cobrirem os diferentes postos, tem que pelo menos um dos enfermeiros em serviço cobrir o posto que não possua nenhum assitente operacional."},
                new Regras { Nome = "Postos v2", Descricao = "Um colaborador não pode trabalhar no mesmo posto pelo menos dois dias seguidos."}
                
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
                new Posto { Nome = "Embalagem e esterilização"}
            );

            db.SaveChanges();
        }

        private static void SeedTurno(MaterialDbContext db)
        {
            if (db.Turno.Any()) return;

            db.Turno.AddRange(
               new Turno { Nome = "MANHÃ", HoraInicio = new DateTime(1, 1, 1, 8, 0, 0), HoraFim = new DateTime(1, 1, 1, 16, 0, 0) },
               new Turno { Nome = "TARDE", HoraInicio = new DateTime(1, 1, 1, 16, 0, 0), HoraFim = new DateTime(1, 1, 1, 0, 0, 0) }

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
            Funcao DiretorServiço = GetFuncaoCreatingIfNeed(db, "Diretor de Serviço");

            db.Colaborador.AddRange(
                       new Colaborador
                       {                            
                           Nome = "Joaquim Lopes Mendes",
                           Email = "mail@mail.com",
                           Telefone = "961234567",
                           Cc = "12345678",
                           DataNasc = new DateTime(1977, 5, 19),
                           FuncaoID = Enfermeiro.FuncaoID,
                           Morada = "Rua nº1, Guarda",
                       },
                       new Colaborador
                       {
                           Nome = "Filipe Correia Goncalves",
                           Email = "mail@mail.com",
                           Telefone = "961624587",
                           Cc = "13210224",
                           DataNasc = new DateTime(1972 , 07 , 03),
                           FuncaoID = Enfermeiro.FuncaoID,
                           Morada = "Rua nº2, guarda",
                       },
                      new Colaborador
                      {

                          Nome = "Maria Silva",
                          Email = "mail@mail.com",
                          Telefone = "961234567",
                          Cc = "63214587",
                          DataNasc = new DateTime(1978 , 08 , 04),
                          FuncaoID = AssistenteOperacional.FuncaoID,
                          Morada = "Rua nº3, guarda",
                      },
                           
                          new Colaborador
                          {

                              Nome = "João Marco Ramos",
                              Email = "mail@mail.com",
                              Telefone = "932145698",
                              Cc = "56987456",
                              DataNasc = new DateTime(1985 , 02 , 01),
                              FuncaoID = Enfermeiro.FuncaoID,
                              Morada = "Rua nº4, Guarda",
                          },
                               new Colaborador
                               {

                                   Nome = "Ana Costa Teixeira",
                                   Email = "mail@mail.com",
                                   Telefone = "912358742",
                                   Cc = "32014589",
                                   DataNasc = new DateTime(1988 , 09 , 16),
                                   FuncaoID = AssistenteOperacional.FuncaoID,
                                   Morada = "Rua nº5, Guarda",
                               },
                               new Colaborador
                               {

                                   Nome = "Ricardo Mendes",
                                   Email = "mail@mail.com",
                                   Telefone = "932145699",
                                   Cc = "39756321",
                                   DataNasc = new DateTime(1994 , 08 , 25),
                                   FuncaoID = AssistenteOperacional.FuncaoID,
                                   Morada = "Rua nº6, Guarda",
                               },
                               new Colaborador
                               {

                                   Nome = "Daniela Vaz",
                                   Email = "mail@mail.com",
                                   Telefone = "961234567",
                                   Cc = "96321458",
                                   DataNasc = new DateTime(1973 , 05 , 06),
                                   FuncaoID = Enfermeiro.FuncaoID,
                                   Morada = "rua nº7, guarda",
                               },
                                                  
                               new Colaborador
                                           {
                           
                            Nome = "Tiago Lima Rocha",
                             Email = "mail@mail.com",
                            Telefone = "932014789",
                           Cc = "32147856",
                           DataNasc = new DateTime(1974 ,04 , 15),
                          FuncaoID = Enfermeiro.FuncaoID,
                           Morada = "Rua nº7, Guarda",
                                                  },

                            new Colaborador
                                                  {

                                  Nome = "Maria Barros Ribeiro",
                                  Email = "mail@mail.com",
                                  Telefone = "932146399",
                                  Cc = "39963321",
                                  DataNasc = new DateTime(1991 , 06 , 22),
                                  FuncaoID = AssistenteOperacional.FuncaoID,
                                  Morada = "Rua nº8, Guarda",
                                                  },

                              new Colaborador
                               {

                                   Nome = "Rafaela Silva Ribeiro",
                                   Email = "mail@mail.com",
                                   Telefone = "932145679",
                                   Cc = "39756321",
                                   DataNasc = new DateTime(1974 , 05 , 04),
                                   FuncaoID = Enfermeiro.FuncaoID,
                                   Morada = "Rua nº9, Guarda",
                               },
                        new Colaborador
                               {

                                   Nome = "Vitória Rocha Azevedo",
                                   Email = "mail@mail.com",
                                   Telefone = "963245699",
                                   Cc = "74126321",
                                   DataNasc = new DateTime(1994 , 05 , 17),
                                   FuncaoID = Enfermeiro.FuncaoID,
                                   Morada = "Rua nº10, Guarda",
                               },
                                new Colaborador
                               {

                                   Nome = "Daniel Pereira Santos",
                                   Email = "mail@mail.com",
                                   Telefone = "963214699",
                                   Cc = "23658321",
                                   DataNasc = new DateTime(1984 , 07 , 15),
                                   FuncaoID = AssistenteOperacional.FuncaoID,
                                   Morada = "Rua nº11, Guarda",
                               },
                              new Colaborador
                               {

                                   Nome = "António Correia Ferreira",
                                   Email = "mail@mail.com",
                                   Telefone = "915478963",
                                   Cc = "98756321",
                                   DataNasc = new DateTime(1988 , 01 , 12),
                                   FuncaoID = Enfermeiro.FuncaoID,
                                   Morada = "Rua nº12, Guarda",
                               },

                                new Colaborador
                               {

                                   Nome = "Tiago Costa Carvalho",
                                   Email = "mail@mail.com",
                                   Telefone = "913459875",
                                   Cc = "39756321",
                                   DataNasc = new DateTime(1980 , 06 , 03),
                                   FuncaoID = DiretorServiço.FuncaoID,
                                   Morada = "Rua nº13, Guarda",
                               }
                   );
            db.SaveChanges();

        }
   
        private static Horario GetHorarioCreatingIfNeed(MaterialDbContext db, int id)
        {
            Horario horario = db.Horario.SingleOrDefault(e => e.HorarioID == id);

            if (horario == null)
            {
                horario = new Horario { HorarioID = id };
                db.Add(horario);
                db.SaveChanges();
            }

            return horario;
        }
        private static Colaborador GetColaboradorCreatingIfNeed(MaterialDbContext db, string Nome)
        {
            Colaborador colaborador = db.Colaborador.SingleOrDefault(e => e.Nome == Nome);

            if (colaborador == null)
            {
                colaborador = new Colaborador { Nome = Nome };
                db.Add(colaborador);
                db.SaveChanges();
            }

            return colaborador;
        }

        private static Turno GetTurnoCreatingIfNeed(MaterialDbContext db, string Nome)
        {
            Turno turno = db.Turno.SingleOrDefault(e => e.Nome == Nome);

            if (turno == null)
            {
                turno = new Turno { Nome = Nome };
                db.Add(turno);
                db.SaveChanges();
            }

            return turno;
        }

        private static Posto GetPostoCreatingIfNeed(MaterialDbContext db, string Nome)
        {
            Posto posto = db.Posto.SingleOrDefault(e => e.Nome == Nome);

            if (posto == null)
            {
                posto = new Posto { Nome = Nome };
                db.Add(posto);
                db.SaveChanges();
            }

            return posto;
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
