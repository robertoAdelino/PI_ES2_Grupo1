using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class SeedData
    {
        public static void Populate(IServiceProvider applicationServices)
        {
            using (var serviceScope = applicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ServicoDeEsterelizacaoContext>();

                if (db.InfoModel.Any()) return;


                db.InfoModel.AddRange(
                //    new Product 
                     );
                db.SaveChanges();
            }
        }
    }
}
