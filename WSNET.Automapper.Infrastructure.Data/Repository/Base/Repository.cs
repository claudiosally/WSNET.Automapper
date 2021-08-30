using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using WSNET.Automapper.Domain.Entity.Base;
using WSNET.Automapper.Domain.Repository.Base;
using WSNET.Automapper.Infrastructure.Data.Repository.Base.Interface;

namespace WSNET.Automapper.Infrastructure.Data.Repository.Base
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ICollection<T> _dbSet;

        protected Repository(IDataBase dataBase)
        {
            _dbSet = dataBase.DbSet<T>();
        }

        public Task<IEnumerable<T>> GetAllAsync() => Task.FromResult((IEnumerable<T>)_dbSet);

        public Task<IEnumerable<T>> GetAllAsync(Func<T, bool> query) => Task.FromResult(_dbSet.Where(query));

        public Task<T> GetAsync(Guid id) => Task.FromResult(_dbSet.FirstOrDefault(e => e.Id.Equals(id)));
 
        public Task InsertAsync(T entity)
        {
            _dbSet.Add(entity);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(T entity)
        {
            using TransactionScope scope = new();
            var dbEntity = await GetAsync(entity.Id);
            await DeleteAsync(dbEntity);
            await InsertAsync(entity);
            scope.Complete();
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }
    }
}
