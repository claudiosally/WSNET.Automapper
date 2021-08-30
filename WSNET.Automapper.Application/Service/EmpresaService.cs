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
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaBusiness _business;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaBusiness empresaBusiness, IMapper mapper)
        {
            _business = empresaBusiness;
            _mapper = mapper;
        }

        public async Task<EmpresaViewModel> CadastrarAsync(CadastroEmpresaViewModel viewModel)
        {
            var empresa = _mapper.Map<Empresa>(viewModel);
            await _business.CadastrarAsync(empresa);
            return _mapper.Map<EmpresaViewModel>(empresa);
        }

        public async Task<EmpresaViewModel> ObterEmpresaPelaRazaoSocial(string razaoSocial)
        {
            var empresa = await _business.ObterPelaRazaoSocialAsync(razaoSocial);

            if (empresa != null)
            {
                return _mapper.Map<EmpresaViewModel>(empresa);
            }

            return default;
        }

        public async Task<EmpresaViewModel> ObterEmpresaPeloCNPJ(string cnpj)
        {
            var empresa = await _business.ObterPeloCnpjAsync(cnpj);

            if (empresa != null)
            {
                return _mapper.Map<EmpresaViewModel>(empresa);
            }

            return default;
        }

        public async Task<EmpresaViewModel> ObterEmpresaPeloId(Guid id)
        {
            var empresa = await _business.ObterPeloIdAsync(id);

            if (empresa != null)
            {
                return _mapper.Map<EmpresaViewModel>(empresa);
            }

            return default;
        }

        public async Task<IEnumerable<EmpresaViewModel>> ObterTodas(bool? ativos)
        {
            if (ativos.HasValue)
            {
                return _mapper.Map<IEnumerable<EmpresaViewModel>>(await _business.ListarComQueryAsync(e => e.Ativo.Equals(ativos.Value)));
            }
            return _mapper.Map<IEnumerable<EmpresaViewModel>>(await _business.ListarTodosAsync());
        }
    }
}
