using WSNET.Automapper.Domain.Entity.Base;

namespace WSNET.Automapper.Domain.Entity
{
    public class Empresa : BaseEntity
    {
        public string RazaoSocial { get; set; }         
        public string CNPJ { get; set; }

        public Empresa() : base() { }
    }
}
