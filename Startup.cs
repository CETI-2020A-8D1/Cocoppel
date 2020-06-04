using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cocoppel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cocoppel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Método ConfigureServices
        /// Configura servicios de base de datos y enrutamiento por atributos de controladores
        /// </summary>
        /// <param name="services">Interfaz de servicios por configurar</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CocoppelContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CocoppelDatabase")));
            services.AddControllers();
        }

        /// <summary>
        /// Método Configure
        /// Usado para configurar el entorno de la aplicación y web hosting
        /// </summary>
        /// <param name="app">Interfaz de aplicación por configurar</param>
        /// <param name="env">Interfaz de entorno web por configurar</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
