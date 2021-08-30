using System;

namespace WSNET.Automapper.Application.ViewModel
{
    public class AtualizacaoPessoaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool? Ativo { get; set; }
    }
}
