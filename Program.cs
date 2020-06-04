using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cocoppel
{
    /// <summary>
    /// Clase Program
    /// Punto de entrada del REST Web API Cocoppel
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método Main
        /// Punto de entrada de la aplicación
        /// </summary>
        /// <param name="args">Argumentos de la consola de comandos</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        /// <summary>
        /// Método CreateHostBuilder
        /// Usado para crear una Web API
        /// </summary>
        /// <param name="args">Argumentos de la consola de comandos</param>
        /// <returns>El web host</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
