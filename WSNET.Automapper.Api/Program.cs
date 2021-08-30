using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Enrichers.Span;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;

namespace WSNET.Automapper.Api
{
    public class Program
    {
        protected Program() { }

        private static readonly string ENVIRONMENT =
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Production;

        /// <summary> IConfiguration inicializado antes do tempo padrão para carregar as configurações de logging </summary>
        private static IConfiguration _configurationForLogging;

        public static void Main(string[] args)
        {
            _configurationForLogging = CreateConfigurationForLogging(args);

            /*
             * O logger precisa ser criado antes de inicializar a aplicação para que
             * erros de inicialização sejam logados
             */
            Serilog.Log.Logger = CreateLogger();
            try
            {
                Serilog.Log.Information("Iniciando aplicação");
                CreateHostBuilder(args).Build().Run();
                _configurationForLogging = null;
            }
            catch (Exception ex)
            {
                Serilog.Log.Fatal(ex, "Aplicação encerrou de forma inesperada");
            }
            finally
            {
                Serilog.Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

        private static IConfiguration CreateConfigurationForLogging(string[] args)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ENVIRONMENT}.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<Program>(optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }

        private static Logger CreateLogger()
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(_configurationForLogging)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                    .WithIgnoreStackTraceAndTargetSiteExceptionFilter()
                    .WithDefaultDestructurers()
                )
                .Enrich.WithProperty("Environment", ENVIRONMENT)
                .Enrich.WithSpan();

            return logger.CreateLogger();
        }
    }
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        CreateHostBuilder(args).Build().Run();
    //    }

    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
    //        Host.CreateDefaultBuilder(args)
    //            .ConfigureWebHostDefaults(webBuilder =>
    //            {
    //                webBuilder.UseStartup<Startup>();
    //            });
    //}
}
