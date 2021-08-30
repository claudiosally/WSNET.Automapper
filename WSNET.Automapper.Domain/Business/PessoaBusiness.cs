using System;
using System.Linq;
using System.Threading.Tasks;
using WSNET.Automapper.Domain.Business.Base;
using WSNET.Automapper.Domain.Business.Interface;
using WSNET.Automapper.Domain.Entity;
using WSNET.Automapper.Domain.Repository;

namespace WSNET.Automapper.Domain.Business
{
    public class PessoaBusiness : Business<Pessoa>,  IPessoaBusiness
    {
        public PessoaBusiness(IPessoaRepository repository)
            :base(repository)
        {
        }

        public async Task<Pessoa> ObterPeloCpfAsync(string cpf)
        {
            return (await _repository.GetAllAsync(e => e.CPF.Equals(cpf))).FirstOrDefault();
        }

        public async Task<Pessoa> ObterPeloNomeAsync(string nome)
        {
            return (await _repository.GetAllAsync(e => e.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
        }
    }
}
