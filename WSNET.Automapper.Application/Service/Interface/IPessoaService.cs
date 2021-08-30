using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSNET.Automapper.Application.ViewModel;

namespace WSNET.Automapper.Application.Service.Interface
{
    public interface IPessoaService
    {
        Task<PessoaViewModel> ObterPessoaPeloId(Guid id);
        Task<PessoaViewModel> ObterPessoaPeloCPF(string cpf);
        Task<PessoaViewModel> ObterPessoaPeloNome(string nome);
        Task<IEnumerable<PessoaViewModel>> ObterTodos(bool? ativos);
        Task<PessoaViewModel> CadastrarAsync(CadastroPessoaViewModel viewModel);
        Task<PessoaViewModel> AtualizarAsync(AtualizacaoPessoaViewModel viewModel);
        Task ApagarPessoa(Guid idPessoa);
    }
}
