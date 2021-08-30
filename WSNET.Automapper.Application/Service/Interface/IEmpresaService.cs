using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSNET.Automapper.Application.ViewModel;

namespace WSNET.Automapper.Application.Service.Interface
{
    public interface IEmpresaService
    {
        Task<EmpresaViewModel> ObterEmpresaPeloId(Guid id);
        Task<EmpresaViewModel> ObterEmpresaPeloCNPJ(string cnpj);
        Task<EmpresaViewModel> ObterEmpresaPelaRazaoSocial(string razaoSocial);
        Task<IEnumerable<EmpresaViewModel>> ObterTodas(bool? ativos);
        Task<EmpresaViewModel> CadastrarAsync(CadastroEmpresaViewModel viewModel);
    }
}
