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
        /// M�todo Main
        /// Punto de entrada de la aplicaci�n
        /// </summary>
        /// <param name="args">Argumentos de la consola de comandos</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        /// <summary>
        /// M�todo CreateHostBuilder
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
