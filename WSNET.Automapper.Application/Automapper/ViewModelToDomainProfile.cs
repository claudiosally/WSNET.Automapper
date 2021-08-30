using AutoMapper;
using System.Text.RegularExpressions;
using WSNET.Automapper.Application.Automapper.Resolvers;
using WSNET.Automapper.Application.ViewModel;
using WSNET.Automapper.Domain.Entity;

namespace WSNET.Automapper.Application.Automapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<CadastroPessoaViewModel, Pessoa>()
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => Regex.Replace(src.CPF, "[^0-9]+", "")));

            CreateMap<AtualizacaoPessoaViewModel, Pessoa>()
                .ForMember(dest => dest.Nome, opt => opt.PreCondition((src) => !string.IsNullOrEmpty(src.Nome)))
                .ForMember(dest => dest.Telefone, opt => opt.PreCondition((src) => !string.IsNullOrEmpty(src.Telefone)))
                .ForMember(dest => dest.RG, opt => opt.PreCondition((src) => !string.IsNullOrEmpty(src.RG)))
                .ForMember(dest => dest.DataNascimento, opt => opt.PreCondition((src) => src.DataNascimento.HasValue))
                .ForMember(dest => dest.Ativo, opt => opt.PreCondition((src) => src.Ativo.HasValue))
                .ForMember(dest => dest.CPF, opt =>
                {
                    opt.PreCondition((src) => !string.IsNullOrEmpty(src.CPF));
                    opt.MapFrom(src => Regex.Replace(src.CPF, "[^0-9]+", ""));
                });

            CreateMap<CadastroEmpresaViewModel, Empresa>();

            CreateMap<CadastroProdutoViewModel, Produto>()
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom<CadastroProdutoEmpresaResolver>());
        }
    }
}
