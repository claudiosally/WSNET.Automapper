using System.Threading.Tasks;
using WSNET.Automapper.Domain.Business.Base.Interface;
using WSNET.Automapper.Domain.Entity;

namespace WSNET.Automapper.Domain.Business.Interface
{
    public interface IPessoaBusiness : IBusiness<Pessoa>
    {
        Task<Pessoa> ObterPeloCpfAsync(string cpf);
        Task<Pessoa> ObterPeloNomeAsync(string nome);
    }
}
