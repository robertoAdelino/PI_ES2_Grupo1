using Microsoft.Extensions.DependencyInjection;
using ServicoDeEsterelizacao.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class SeedData1
    {
        public static void Populate(IServiceProvider applicationServices)
        {
            using (var serviceScope = applicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (db.InfoModel.Any()) return;

                db.InfoModel.AddRange(
                        
                    
                    
                    
                    
                    );
                db.SaveChanges();
            }
        }
    }
}
