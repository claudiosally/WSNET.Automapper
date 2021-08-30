using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSNET.Automapper.Domain.Entity.Base;

namespace WSNET.Automapper.Domain.Repository.Base
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Func<T, bool> query);
    }
}
