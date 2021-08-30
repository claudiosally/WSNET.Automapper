using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSNET.Automapper.Application.ViewModel;

namespace WSNET.Automapper.Application.Service.Interface
{
    public interface IProdutoService
    {
        Task<ProdutoViewModel> ObterProdutoPeloId(Guid id);
        Task<ProdutoViewModel> ObterProdutoPelaDescricao(string descricao);
        Task<IEnumerable<ProdutoViewModel>> ObterTodos(bool? ativos);
        Task<ProdutoViewModel> CadastrarAsync(CadastroProdutoViewModel viewModel);
        Task ApagarProduto(Guid idProduto);
    }
}
