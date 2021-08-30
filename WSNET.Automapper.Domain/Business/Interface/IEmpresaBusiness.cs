using System.Threading.Tasks;
using WSNET.Automapper.Domain.Business.Base.Interface;
using WSNET.Automapper.Domain.Entity;

namespace WSNET.Automapper.Domain.Business.Interface
{
    public interface IEmpresaBusiness : IBusiness<Empresa>
    {
        Task<Empresa> ObterPeloCnpjAsync(string cnpj);
        Task<Empresa> ObterPelaRazaoSocialAsync(string razaoSocial);        
    }
}
