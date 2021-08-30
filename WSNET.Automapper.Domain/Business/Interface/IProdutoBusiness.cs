using System.Collections.Generic;
using System.Threading.Tasks;
using WSNET.Automapper.Domain.Business.Base.Interface;
using WSNET.Automapper.Domain.Entity;

namespace WSNET.Automapper.Domain.Business.Interface
{
    public interface IProdutoBusiness : IBusiness<Produto>
    {
        Task<Produto> ObterPelaDescricaoAsync(string descricao);
        Task<IEnumerable<Produto>> ListarPorEmpresaAsync(Empresa empresa);
    }
}
