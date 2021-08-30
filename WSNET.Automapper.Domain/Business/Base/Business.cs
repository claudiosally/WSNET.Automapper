using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSNET.Automapper.Domain.Business.Base.Interface;
using WSNET.Automapper.Domain.Entity.Base;
using WSNET.Automapper.Domain.Repository.Base;

namespace WSNET.Automapper.Domain.Business.Base
{
    public abstract class Business<T> : IBusiness<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        protected Business(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task ApagarAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task AtualizarAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task CadastrarAsync(T entity)
        {
            await _repository.InsertAsync(entity);
        }

        public Task<IEnumerable<T>> ListarComQueryAsync(Func<T, bool> query)
        {
            return _repository.GetAllAsync(query);
        }

        public Task<IEnumerable<T>> ListarTodosAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<T> ObterComQueryAsync(Func<T, bool> query)
        {
            return (await _repository.GetAllAsync(query)).FirstOrDefault();
        }

        public Task<T> ObterPeloIdAsync(Guid id)
        {
            return _repository.GetAsync(id);
        }
    }
}
