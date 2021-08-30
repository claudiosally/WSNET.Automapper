using System;

namespace WSNET.Automapper.Application.ViewModel
{
    public class CadastroPessoaViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }        
        public DateTime DataNascimento { get; set; }
    }
}
