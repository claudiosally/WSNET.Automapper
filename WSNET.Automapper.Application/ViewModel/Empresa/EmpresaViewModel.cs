using System.Collections.Generic;

namespace WSNET.Automapper.Application.ViewModel
{
    public class EmpresaViewModel
    {
        public string Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Status { get; set; }

        public ICollection<ProdutoViewModel> Produtos { get; set; }
    }
}
