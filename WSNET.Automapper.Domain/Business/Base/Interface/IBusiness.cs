using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSNET.Automapper.Domain.Entity.Base;

namespace WSNET.Automapper.Domain.Business.Base.Interface
{
    public interface IBusiness<T> where T : BaseEntity
    {
        Task CadastrarAsync(T entity);
        Task AtualizarAsync(T entity);
        Task ApagarAsync(T entity);
        Task<T> ObterPeloIdAsync(Guid id);
        Task<T> ObterComQueryAsync(Func<T, bool> query);
        Task<IEnumerable<T>> ListarTodosAsync();
        Task<IEnumerable<T>> ListarComQueryAsync(Func<T, bool> query);
    }
}
