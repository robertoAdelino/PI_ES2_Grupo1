using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ServicoDeEsterelizacao.Models;
using Microsoft.AspNetCore.Identity;

namespace ServicoDeEsterelizacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
/*
            services.AddIdentity<AppUser, IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<MaterialDbContext>();
            */
            services.AddDbContext<ServicoDeEsterelizacaoContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ServicoDeEsterelizacaoContext")));

            services.AddDbContext<MaterialDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MaterialDbContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                    MaterialDbContext db, UserManager<IdentityUser> userManager
                     /*,RoleManager<IdentityRole> roleManager*/)
        {

          //  SeedDataMaterial.Populate(app.ApplicationServices);
            //SeedDataMaterial.CreateRolesAndUsersAsync(userManager, roleManager).Wait();
            /*
                        if (env.IsDevelopment())
                        {
                            SeedDataMaterial.CreateTestUsersAsync(userManager, roleManager).Wait(); // Must be the first thing to do
                            SeedDataMaterial.Populate(app.ApplicationServices);

                            app.UseDeveloperExceptionPage();
                            app.UseDatabaseErrorPage();
                        }
                        else
                        {
                            app.UseExceptionHandler("/Home/Error");
                            app.UseHsts();
                        }*/

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
