using Microsoft.Extensions.DependencyInjection;
using WSNET.Automapper.Application.Automapper;
using WSNET.Automapper.Application.Automapper.Resolvers;

namespace WSNET.Automapper.CrossCutting.Configs
{
    public static class AutomapperConfig
    {
        public static IServiceCollection AddAutomapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToViewModelProfile), 
                                   typeof(ViewModelToDomainProfile), 
                                   typeof(CadastroProdutoEmpresaResolver),
                                   typeof(CpfPessoaFormatacaoResolver),
                                   typeof(EmpresaViewModelProdutosResolver));

            return services;
        }
    }
}
