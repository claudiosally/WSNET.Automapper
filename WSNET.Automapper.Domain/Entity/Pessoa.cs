using System;
using WSNET.Automapper.Domain.Entity.Base;

namespace WSNET.Automapper.Domain.Entity
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public Pessoa() : base() { }
    }
}
