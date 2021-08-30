using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSNET.Automapper.Application.Service.Interface;
using WSNET.Automapper.Application.ViewModel;
using WSNET.Automapper.Domain.Business.Interface;
using WSNET.Automapper.Domain.Entity;

namespace WSNET.Automapper.Application.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoBusiness _business;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        public async Task ApagarProduto(Guid idProduto)
        {
            var produto = await _business.ObterPeloIdAsync(idProduto);
            await _business.ApagarAsync(produto);
        }

        public async Task<ProdutoViewModel> CadastrarAsync(CadastroProdutoViewModel viewModel)
        {
            var produto = _mapper.Map<Produto>(viewModel);
            await _business.CadastrarAsync(produto);
            return _mapper.Map<ProdutoViewModel>(produto);
        }

        public async Task<ProdutoViewModel> ObterProdutoPelaDescricao(string descricao)
        {
            var produto = await _business.ObterPelaDescricaoAsync(descricao);

            if (produto != null)
            {
                return _mapper.Map<ProdutoViewModel>(produto);
            }

            return default;
        }

        public async Task<ProdutoViewModel> ObterProdutoPeloId(Guid id)
        {
            var produto = await _business.ObterPeloIdAsync(id);

            if (produto != null)
            {
                return _mapper.Map<ProdutoViewModel>(produto);
            }

            return default;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos(bool? ativos)
        {
            if (ativos.HasValue)
            {
                return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _business.ListarComQueryAsync(e => e.Ativo.Equals(ativos.Value)));
            }
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _business.ListarTodosAsync());
        }
    }
}
