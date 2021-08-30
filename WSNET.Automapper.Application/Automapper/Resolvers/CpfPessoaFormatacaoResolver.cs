using AutoMapper;
using WSNET.Automapper.Application.ViewModel;
using WSNET.Automapper.Domain.Entity;

namespace WSNET.Automapper.Application.Automapper.Resolvers
{
    public class CpfPessoaFormatacaoResolver : IValueResolver<Pessoa, PessoaViewModel, string>
    {
        public string Resolve(Pessoa source, PessoaViewModel destination, string destMember, ResolutionContext context)
        {
            if ((source.CPF ??"").Length.Equals(11))
            {
                return $"{source.CPF.Substring(0, 3)}.{source.CPF.Substring(3, 3)}.{source.CPF.Substring(6, 3)}-{source.CPF.Substring(9, 2)}";
            }
            return source.CPF;
        }
    }
}
