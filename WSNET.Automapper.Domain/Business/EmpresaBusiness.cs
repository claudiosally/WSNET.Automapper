using System;
using System.Linq;
using System.Threading.Tasks;
using WSNET.Automapper.Domain.Business.Base;
using WSNET.Automapper.Domain.Business.Interface;
using WSNET.Automapper.Domain.Entity;
using WSNET.Automapper.Domain.Repository;

namespace WSNET.Automapper.Domain.Business
{
    public class EmpresaBusiness : Business<Empresa>, IEmpresaBusiness
    {
        public EmpresaBusiness(IEmpresaRepository repository)
            : base(repository)
        {
        }

        public async Task<Empresa> ObterPelaRazaoSocialAsync(string razaoSocial)
        {
            return (await _repository.GetAllAsync(e => e.RazaoSocial.Equals(razaoSocial, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
        }

        public async Task<Empresa> ObterPeloCnpjAsync(string cnpj)
        {
            return (await _repository.GetAllAsync(e => e.CNPJ.Equals(cnpj))).FirstOrDefault();
        }
    }
}
