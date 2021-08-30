﻿using WSNET.Automapper.Domain.Entity;
using WSNET.Automapper.Domain.Repository;
using WSNET.Automapper.Infrastructure.Data.Repository.Base;
using WSNET.Automapper.Infrastructure.Data.Repository.Base.Interface;

namespace WSNET.Automapper.Infrastructure.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IDataBase dataBase) : base(dataBase)
        {
        }
    }
}
