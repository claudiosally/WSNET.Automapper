using AutoMapper;
using System.Collections.Generic;
using WSNET.Automapper.Application.ViewModel;
using WSNET.Automapper.Domain.Business.Interface;
using WSNET.Automapper.Domain.Entity;

namespace WSNET.Automapper.Application.Automapper.Resolvers
{
    public class EmpresaViewModelProdutosResolver : IValueResolver<Empresa, EmpresaViewModel, ICollection<ProdutoViewModel>>
    {
        protected readonly IProdutoBusiness _produtoBusiness;

        public EmpresaViewModelProdutosResolver(IProdutoBusiness produtoBusiness)
        {
            _produtoBusiness = produtoBusiness;
        }

        public ICollection<ProdutoViewModel> Resolve(Empresa source, EmpresaViewModel destination, ICollection<ProdutoViewModel> destMember, ResolutionContext context)
        {
            var produtos = _produtoBusiness.ListarPorEmpresaAsync(source).Result;

            return context.Mapper.Map<ICollection<ProdutoViewModel>>(produtos);
        }
    }
}
