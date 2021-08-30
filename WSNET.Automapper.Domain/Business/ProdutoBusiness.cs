using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSNET.Automapper.Domain.Business.Base;
using WSNET.Automapper.Domain.Business.Interface;
using WSNET.Automapper.Domain.Entity;
using WSNET.Automapper.Domain.Repository;

namespace WSNET.Automapper.Domain.Business
{
    public class ProdutoBusiness : Business<Produto>, IProdutoBusiness
    {
        public ProdutoBusiness(IProdutoRepository repository) 
            : base(repository)
        {
        }

        public async Task<IEnumerable<Produto>> ListarPorEmpresaAsync(Empresa empresa)
        {
            return await _repository.GetAllAsync(e => e.Empresa.Id.Equals(empresa.Id));
        }

        public async Task<Produto> ObterPelaDescricaoAsync(string descricao)
        {
            return (await _repository.GetAllAsync(e => e.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
        }
    }
}
