using Microsoft.Extensions.DependencyInjection;
using WSNET.Automapper.Application.Service;
using WSNET.Automapper.Application.Service.Interface;
using WSNET.Automapper.Domain.Business;
using WSNET.Automapper.Domain.Business.Interface;
using WSNET.Automapper.Domain.Repository;
using WSNET.Automapper.Domain.Services;
using WSNET.Automapper.Domain.Services.Interface;
using WSNET.Automapper.Infrastructure.Data;
using WSNET.Automapper.Infrastructure.Data.Repository;
using WSNET.Automapper.Infrastructure.Data.Repository.Base.Interface;

namespace WSNET.Automapper.CrossCutting.Configs
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApiConfigurationIoC(this IServiceCollection services)
        {
            //IoC serviços
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            //IoC negócio
            services.AddScoped<IPessoaBusiness, PessoaBusiness>();
            services.AddScoped<IEmpresaBusiness, EmpresaBusiness>();
            services.AddScoped<IProdutoBusiness, ProdutoBusiness>();

            //IoC repositórios
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //IoC banco
            services.AddSingleton<IDataBase, MemoryDatabase>();

            //IoC Services
            services.AddScoped<INotification, Notification>();
                
            return services;
        }
    }
}
