using System;
using System.Collections.Generic;
using WSNET.Automapper.Domain.Entity;
using WSNET.Automapper.Domain.Entity.Base;
using WSNET.Automapper.Infrastructure.Data.Repository.Base.Interface;

namespace WSNET.Automapper.Infrastructure.Data
{
    public class MemoryDatabase : IDataBase
    {
        private readonly Dictionary<Type, object> _dbSets;

        public MemoryDatabase()
        {
            _dbSets = new Dictionary<Type, object>
            {
                { typeof(Pessoa), new HashSet<Pessoa>() },
                { typeof(Empresa), new HashSet<Empresa>() },
                { typeof(Produto), new HashSet<Produto>() }
            };
        }

        public ICollection<T> DbSet<T>() where T : BaseEntity
        {
            return _dbSets[typeof(T)] as ICollection<T>;
        }
    }
}
