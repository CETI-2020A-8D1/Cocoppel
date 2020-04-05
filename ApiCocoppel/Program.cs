using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCocoppel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiCocoppel
{
    public class Program
    {
        bool MaximoCobro(LineaCredito credit) //Si el credito es menor al limite de saldo devuelve verdadero si no, devuelve falso
        {
            if (credit.SaldoRestante < credit.CantidadMaximaDisponible)
            {
                return true;
            }

            return false;
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
