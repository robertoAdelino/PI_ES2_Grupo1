using Microsoft.Extensions.DependencyInjection;
using ServicoDeEsterelizacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Data
{
    public class SeedData1
    {
        internal static void Populate(IServiceProvider applicationServices)
        {
                using (var serviceScope = applicationServices.CreateScope())
                {
                    var db = serviceScope.ServiceProvider.GetService<ServicoDbContext>();

                    //SeedData2.SeedColab(db);
                    SeedHorario(db);
                    SeedServicco(db);
                
                
                    /*var usermanager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();

                    CreateAppUsersAsync(usermanager);*/

                }
            
        }

        private static void SeedServicco(ServicoDbContext db)
        {
            throw new NotImplementedException();
        }

        private static void SeedHorario(ServicoDbContext db)
        {
            throw new NotImplementedException();
        }


    }
}
