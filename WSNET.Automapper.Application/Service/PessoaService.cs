using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSNET.Automapper.Application.Service.Interface;
using WSNET.Automapper.Application.ViewModel;
using WSNET.Automapper.Domain.Business.Interface;
using WSNET.Automapper.Domain.Entity;
using WSNET.Automapper.Domain.Services.Interface;

namespace WSNET.Automapper.Application.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaBusiness _business;
        private readonly IMapper _mapper;
        private readonly INotification _notification;

        public PessoaService(IPessoaBusiness clienteBusiness, 
                             IMapper mapper, 
                             INotification notification)
        {
            _business = clienteBusiness;
            _mapper = mapper;
            _notification = notification;
        }

        public async Task ApagarPessoa(Guid idPessoa)
        {
            var pessoa = await _business.ObterPeloIdAsync(idPessoa);
            await _business.ApagarAsync(pessoa);
        }

        public async Task<PessoaViewModel> AtualizarAsync(AtualizacaoPessoaViewModel viewModel)
        {
            var pessoa = await _business.ObterPeloIdAsync(viewModel.Id);
            if (pessoa == null)
            {
                _notification.AddFailure(new ValidationFailure("id", "Não foi possível encontrar a pessoa com o identificador informado!"));
                return default;
            }
            
            _mapper.Map(viewModel, pessoa);
            await _business.AtualizarAsync(pessoa);
            return _mapper.Map<PessoaViewModel>(pessoa);
        }

        public async Task<PessoaViewModel> CadastrarAsync(CadastroPessoaViewModel viewModel)
        {
            var pessoa = _mapper.Map<Pessoa>(viewModel);
            await _business.CadastrarAsync(pessoa);
            return _mapper.Map<PessoaViewModel>(pessoa);
        }

        public async Task<PessoaViewModel> ObterPessoaPeloCPF(string cpf)
        {
            var pessoa = await _business.ObterPeloCpfAsync(cpf);

            if (pessoa != null)
            {
                return _mapper.Map<PessoaViewModel>(pessoa);
            }

            return default;
        }

        public async Task<PessoaViewModel> ObterPessoaPeloId(Guid id)
        {
            var pessoa = await _business.ObterPeloIdAsync(id);

            if (pessoa != null)
            {
                return _mapper.Map<PessoaViewModel>(pessoa);
            }

            return default;
        }

        public async Task<PessoaViewModel> ObterPessoaPeloNome(string nome)
        {
            var pessoa = await _business.ObterPeloNomeAsync(nome);

            if (pessoa != null)
            {
                return _mapper.Map<PessoaViewModel>(pessoa);
            }

            return default;
        }

        public async Task<IEnumerable<PessoaViewModel>> ObterTodos(bool? ativos)
        {
            if (ativos.HasValue)
            {
                return _mapper.Map<IEnumerable<PessoaViewModel>>(await _business.ListarComQueryAsync(e => e.Ativo.Equals(ativos.Value)));
            }
            return _mapper.Map<IEnumerable<PessoaViewModel>>(await _business.ListarTodosAsync());
        }
    }
}
