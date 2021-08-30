using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using System;

namespace WSNET.Automapper.Api.ProblemDetails
{
    public class ProblemDetailsCustomOptions : IConfigureOptions<ProblemDetailsOptions>
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IDiagnosticContext _serilogRequestLogCtx;

        public ProblemDetailsCustomOptions(IWebHostEnvironment environment, IDiagnosticContext serilogRequestLogCtx)
        {
            _environment = environment;
            _serilogRequestLogCtx = serilogRequestLogCtx;
        }

        public void Configure(ProblemDetailsOptions options)
        {
            options.IncludeExceptionDetails = (_, _) => !_environment.IsProduction();

            options.ShouldLogUnhandledException = (_, err, _) =>
            {
                // Workaround ao log request middleware não capturando a exception
                _serilogRequestLogCtx.Set("ExceptionMessage", err.Message);
                _serilogRequestLogCtx.Set("Exception", err);
                return false;
            };

            MapExceptions(options);
        }

        /// <summary> Determina o Http Status Code que exceptions específicas devem gerar </summary>
        private static void MapExceptions(ProblemDetailsOptions options)
        {
            options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
        }
    }

    public static class ProbemDetailsConfig
    {
        public static IServiceCollection AddProblemDetailsConfiguration(this IServiceCollection services)
        {
            services.ConfigureOptions<ProblemDetailsCustomOptions>();
            return services.AddProblemDetails();
        }
    }
}
