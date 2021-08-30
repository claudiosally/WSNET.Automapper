using AutoMapper;
using WSNET.Automapper.Application.Automapper.Resolvers;
using WSNET.Automapper.Application.ViewModel;
using WSNET.Automapper.Domain.Entity;

namespace WSNET.Automapper.Application.Automapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>()
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento.ToString("dd/MM/yyyy")))  
                .ForMember(dest => dest.CPF, opt => opt.MapFrom<CpfPessoaFormatacaoResolver>())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Ativo ? "Ativo" : "Inativo"));

            CreateMap<Empresa, EmpresaViewModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Ativo ? "Ativo" : "Inativo"))
                .ForMember(dest => dest.Produtos, opt => opt.MapFrom<EmpresaViewModelProdutosResolver>());

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Ativo ? "Ativo" : "Inativo"))
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => $"{src.Empresa.RazaoSocial} / CNPJ: {src.Empresa.CNPJ}"))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => string.Format("{0:C}", src.Valor)));
        }
    }
}
