using AutoMapper;
using WSNET.Automapper.Application.ViewModel;
using WSNET.Automapper.Domain.Business.Interface;
using WSNET.Automapper.Domain.Entity;

namespace WSNET.Automapper.Application.Automapper.Resolvers
{
    public class CadastroProdutoEmpresaResolver : IValueResolver<CadastroProdutoViewModel, Produto, Empresa>
    {
        protected readonly IEmpresaBusiness _empresaBusiness;

        public CadastroProdutoEmpresaResolver(IEmpresaBusiness empresaBusiness)
        {
            _empresaBusiness = empresaBusiness;
        }

        public Empresa Resolve(CadastroProdutoViewModel source, Produto destination, Empresa destMember, ResolutionContext context)
        {
            return _empresaBusiness.ObterPelaRazaoSocialAsync(source.RazaoSocialEmpresa).Result;
        }
    }
}
