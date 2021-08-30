using WSNET.Automapper.Domain.Entity.Base;

namespace WSNET.Automapper.Domain.Entity
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Empresa Empresa { get; set; }

        public Produto() : base() { }
    }
}
