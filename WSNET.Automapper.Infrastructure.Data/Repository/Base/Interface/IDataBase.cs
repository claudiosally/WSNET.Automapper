using System.Collections.Generic;
using WSNET.Automapper.Domain.Entity.Base;

namespace WSNET.Automapper.Infrastructure.Data.Repository.Base.Interface
{
    public interface IDataBase
    {
        ICollection<T> DbSet<T>() where T : BaseEntity;
    }
}
